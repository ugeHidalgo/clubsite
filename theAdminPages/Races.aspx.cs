using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;
using Ext.Net;


namespace ClubSite.AdminPages
{
    public partial class Races : System.Web.UI.Page
    {
        static Race rUsed;
        static bool newImage;
        static Race oldRUsed;
        static string aMemberUserName = null;
        static Int32 aRaceIdSelectedInCombo = 0;

        private Race LoadRaceFromForm()
        {
            Int32 anId = Convert.ToInt32(txbxID.Text);
            using (ClubSiteContext db = new ClubSiteContext())
            {
                Race aRace = (from r in db.Races where r.Id == anId select r).FirstOrDefault();
                return aRace;
            }
        }
        private void LoadRaceInForm(Race aRace)
        {
            txbxID.Text = Convert.ToString(aRace.Id);
            txbxName.Text = aRace.Name;
            txbxDate.Text = aRace.RaceDate.ToShortDateString();
            imgImage.ImageUrl = aRace.ImageURL;
            imgImage.AlternateText = "(Sin imagen)";
            FileUImg.Text = "";
            //Load data for RaceType combo
            if (aRace.RaceTypeID == 0)
                cbRaceTypes.Value = "";
            else
            {
                object aRaceTypeID = aRace.RaceTypeID;
                cbRaceTypes.Select(aRaceTypeID);
            }
            //ListItem aValue = ddlRaceTypes.Items.FindByValue(txbxRaceTypeID.Text);
            //ddlRaceTypes.SelectedIndex = ddlRaceTypes.Items.IndexOf(aValue);

            if (aRace.Address == null)
            {
                txbxStreet.Text = null;
                txbxCity.Text = null;
                txbxPostalCode.Text = null;
                txbxCountry.Text = null;
                txbxNumber.Text = null;
            }
            else
            {
                txbxStreet.Text = aRace.Address.Street;
                txbxCity.Text = aRace.Address.City;
                txbxPostalCode.Text = aRace.Address.PostalCode;
                txbxCountry.Text = aRace.Address.Country;
                txbxNumber.Text = aRace.Address.Number;
            }
            txbxMemo.Text = aRace.Memo;

            ////To avoid problems with the , and . in decimal numbers
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            txbxLatitud.Text = Convert.ToString(aRace.Latitud, culture);
            txbxLongitud.Text = Convert.ToString(aRace.Longitud, culture);

            //Load Members taken part in actual race   
            LoadDataInGridForMembersInRace();

            //Load age gropus for race
            LoadDataInGridForAgeGroups();

            //Load data for participants
            txbxPartGenFem.Text = Convert.ToString(aRace.PartFem);
            txbxPartGenMasc.Text = Convert.ToString(aRace.PartMasc);

            //Search points asigned to race an put on txbxPoints
            if (aRace.RaceTypeID == 0)
                txbxPoints.Text = "0";
            else if (aRace.RaceType != null)
                txbxPoints.Text = aRace.RaceType.Points.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rUsed = new Race();
                oldRUsed = new Race();
                using (var db = new ClubSiteContext())
                {
                    rUsed = (from races in db.Races
                             orderby races.RaceDate descending, races.Name
                             select races).FirstOrDefault();

                    if (rUsed == null)
                    {
                        rUsed = new Race();
                        X.Msg.Alert("Atención", "No hay ningúna competición registrada en la Base de datos.").Show();
                    }

                    //Load data for racetypes combobox
                    LoadDataInGridForRaceTypes();

                    //Load data for clubbers combobox
                    LoadDataInGridForClubbers();

                    //Load data for Members in Race
                    LoadDataInGridForMembersInRace();

                    oldRUsed.CopyRace(rUsed);
                    LoadRaceInForm(rUsed);
                }
            }
        }
        protected void LoadDataInGridForRaceTypes()
        {
            using (var db = new ClubSiteContext())
            {
                Store storeRaceTypes = this.cbRaceTypes.GetStore();
                storeRaceTypes.DataSource = from rt in db.RaceTypes
                                            join s in db.Sports on rt.SportID equals s.SportID
                                            orderby s.Name, rt.Name
                                            select new { rt.RaceTypeID, Name = (s.Name + " / " + rt.Name) };
                storeRaceTypes.DataBind();
            }
        }
        protected void LoadDataInGridForClubbers()
        {
            using (var db = new ClubSiteContext())
            {
                //Load data for clubbers combobox
                Store storeClubbers = this.cbClubbers.GetStore();
                storeClubbers.DataSource = from m in db.Members
                                           where m.State == true
                                           orderby m.SecondName, m.FirstName
                                           select new { m.UserName, Name = (m.SecondName + ", " + m.FirstName) };
                storeClubbers.DataBind();
            }
        }
        protected void LoadDataInGridForMembersInRace()
        {
            using (var db = new ClubSiteContext())
            {
                //Load data for Members in Race

                Store storeMembersInRace = this.GPClubbersEnComp.GetStore();
                if (rUsed.Id != 0)
                {
                    var aRace = (from r in db.Races
                                 where r.Id == rUsed.Id
                                 select r).FirstOrDefault();
                    storeMembersInRace.DataSource = aRace.Members;
                }
                else
                {
                    storeMembersInRace.DataSource = new List<Member>();
                }
                storeMembersInRace.DataBind();
            }
        }
        private void LoadDataInGridForAgeGroups()
        {
            using (var db = new ClubSiteContext())
            {
                //Load data for Age Groups in Race
                Store storeAgeGroups = this.GPAgeGroupsEnComp.GetStore();
                if (rUsed.Id != 0)
                {
                    var aRace = (from r in db.Races
                                 where r.Id == rUsed.Id
                                 select r).FirstOrDefault();
                    storeAgeGroups.DataSource = aRace.RaceAgeGroups;
                }
                else
                {
                    storeAgeGroups.DataSource = new List<RaceAgeGroup>();
                }
                storeAgeGroups.DataBind();
            }
        }

        //protected void btnDelClubber_Click(object sender, EventArgs e)
        //{
        //    //string messageError = "";
        //    //String memberUserName = lbClubbersTakingPart.Text;
        //    //ListItem memberToDelete = lbClubbersTakingPart.Items.FindByValue(memberUserName);
        //    //if (memberToDelete == null)
        //    //{
        //    //    messageError = "<script>alert('No hay Clubbers para borrar de la carrera')</script>";
        //    //}
        //    //else
        //    //{
        //    //    //Delete clubber/race from BD
        //    //    DeleteClubberTakingPartInRace(memberUserName);

        //    //    //Delete clubber from List Box
        //    //    lbClubbersTakingPart.Items.Remove(memberToDelete);
        //    //    messageError = "<script>alert('Clubbers borrado de la carrera')</script>";
        //    //}
        //    //Response.Write(messageError);
        //}

        ////private void DeleteClubberTakingPartInRace(string memberUserName)
        ////{
        ////    using (var db = new ClubSiteContext())
        ////    {
        ////        Race aRace = (from r in db.Races
        ////                      where r.Id == rUsed.Id
        ////                      select r).FirstOrDefault();

        ////        Member aMember = (from m in db.Members
        ////                          where m.UserName == memberUserName
        ////                          select m).FirstOrDefault();
        ////        aRace.Members.Remove(aMember);
        ////        db.SaveChanges();
        ////    }
        ////}

        protected void cbRaceTypesChangeValue(object sender, DirectEventArgs e)
        {
            //Search points for RaceType Selected
            string points = "";
            try
            {
                Int32 aRaceTypeId = Convert.ToInt32(cbRaceTypes.SelectedItem.Value);
                using (var db = new ClubSiteContext())
                {
                    RaceType aRT = (from rt in db.RaceTypes
                                    where rt.RaceTypeID == aRaceTypeId
                                    select rt).FirstOrDefault();
                    if (aRT != null)
                        points = Convert.ToString(aRT.Points);

                }
                txbxPoints.Text = points;
            }
            catch (Exception)
            {
                txbxPoints.Text = "";
            }
        }

        private bool VerifyIfClubberExist(string aName)
        {
            bool exist = false;
            using (var deb = new ClubSiteContext())
            {
                var item = (from m in deb.Members where m.UserName == aName && m.State == true select m).FirstOrDefault();
                if (item != null) exist = true;
            }
            return exist;
        }

        protected void GPRaces_Cell_Click(object sender, EventArgs e)
        {
            try
            {
                CellSelectionModel sm = this.GPRaces.GetSelectionModel() as CellSelectionModel;
                Int32 actualRId = Convert.ToInt32(sm.SelectedCell.RecordID);
                using (var db = new ClubSiteContext())
                {
                    rUsed = (from races in db.Races
                             where races.Id == actualRId
                             select races).FirstOrDefault();

                    if (rUsed == null)
                        X.Msg.Alert("Atención", "No hay ninguna carrera registrada en la Base de datos.").Show();
                    oldRUsed.CopyRace(rUsed);

                    //Loads model object data into form
                    LoadRaceInForm(rUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }
        protected void StoreCbRaceTypes_ReadData(object sender, Ext.Net.StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.cbRaceTypes.GetStore();
                store.DataSource = from rt in db.RaceTypes
                                   join s in db.Sports on rt.SportID equals s.SportID
                                   orderby s.Name, rt.Name
                                   select new { rt.RaceTypeID, Name = (s.Name + " / " + rt.Name) };
                store.DataBind();
            }
        }
        protected void StoreCbClubbers_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.cbClubbers.GetStore();
                store.DataSource = from m in db.Members
                                   where m.State == true
                                   orderby m.SecondName, m.FirstName
                                   select new { m.UserName, Name = (m.SecondName + ", " + m.FirstName) };
                store.DataBind();
            }
        }
        protected void StoreGPClubbersEnComp_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.GPClubbersEnComp.GetStore();
                var aRace = (from r in db.Races
                             where r.Id == rUsed.Id
                             select r).FirstOrDefault();
                store.DataSource = aRace.Members;
                store.DataBind();
            }

        }
        protected void StoreGPAgeGroupsEnComp_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                //Load data for Age Groups in Race
                Store storeAgeGroups = this.GPAgeGroupsEnComp.GetStore();
                if (rUsed.Id != 0)
                {
                    var aRace = (from r in db.Races
                                 where r.Id == rUsed.Id
                                 select r).FirstOrDefault();
                    storeAgeGroups.DataSource = aRace.RaceAgeGroups;
                }
                else
                {
                    storeAgeGroups.DataSource = new List<RaceAgeGroup>();
                }
                storeAgeGroups.DataBind();
            }

        }

        protected void UploadImgClick(object sender, DirectEventArgs e)
        {
            string tpl = "Subida la imagen: {0}<br/>Size: {1} bytes";

            if (this.FileUImg.HasFile)
            {
                string virtualFolder = "../Images/Races/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUImg.FileName; //Guid.NewGuid().ToString();
                //string extension = System.IO.Path.GetExtension(FileUImg.FileName);
                FileUImg.PostedFile.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgImage.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newImage = true;
                rUsed.ImageURL = imgImage.ImageUrl;
                FileUImg.Clear();
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Terminado",
                    Message = string.Format(tpl, this.FileUImg.PostedFile.FileName, this.FileUImg.PostedFile.ContentLength)
                });
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Error",
                    Message = "No se ha subido ninguna imagen"
                });
            }
            this.FileUImg.Reset();
        }
        protected void BorrarImgClick(object sender, DirectEventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(rUsed.ImageURL));
            imgImage.ImageUrl = null;
            rUsed.ImageURL = null;
            this.FileUImg.Reset();
        }


        [DirectMethod]
        public void AskNew()
        {
            X.Msg.Confirm("Atención", "¿Desea crear una nueva competición?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNew()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNotNew()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNotNew()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la creación de nueva competición" });
        }

        [DirectMethod]
        public void DoNew()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Ficha para nueva competición" });
            oldRUsed.CopyRace(rUsed);
            rUsed.ClearRace();
            LoadRaceInForm(rUsed);
        }

        [DirectMethod]
        public void AskCancel()
        {
            X.Msg.Confirm("Atención", "¿Desea cancelar la edición de la competición actual?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoCancel()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNotCancel()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNotCancel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Puede continuar la edicion." });
        }

        [DirectMethod]
        public void DoCancel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la edición" });
            rUsed.CopyRace(oldRUsed);
            LoadRaceInForm(rUsed);
        }

        [DirectMethod]
        public void AskDel()
        {
            X.Msg.Confirm("Atención", "¿Desea borrar la competición mostrada en la ficha?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoDel()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNotDel()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNotDel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Se ha cancelado el borrado." });
        }

        [DirectMethod]
        public void DoDel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Borrando la competición en pantalla." });
            if (rUsed.Id == 0)
            { //No Race selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay competiciones registradas.").Show();
            }
            else
            {
                //Del race
                using (var db = new ClubSiteContext())
                {
                    Race item = (from races in db.Races
                                 where races.Id == rUsed.Id
                                 select races).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Competición con id : {0} no encontrada", rUsed.Id));
                        X.Msg.Alert("Atención", "Competición no encontrada. Borrado cancelado,").Show();
                        return;
                    }
                    db.Races.Remove(item);
                    db.SaveChanges();
                    this.StoreGPRaces.DataBind();
                    X.Msg.Alert("Atención", "Competición borrada.").Show();

                    //Load data for first race type
                    rUsed = (from races in db.Races
                             orderby races.RaceDate descending, races.Name
                             select races).FirstOrDefault();
                    if (rUsed == null)
                    {
                        //Last item was erased. No items in BD.
                        rUsed = new Race();
                        X.Msg.Alert("Atención", "No queda ninguna competición registrada en la Base de datos.").Show();
                    }
                    oldRUsed.CopyRace(rUsed);
                    //Loads model object data into form
                    LoadRaceInForm(rUsed);
                }
            }
        }

        [DirectMethod]
        public void AskSave()
        {
            bool sigue = true;
            string messageError = null;

            //Verify name exists
            if (txbxName.Text == "")
            {
                sigue = false;
                messageError = "Falta el nombre de la competición.";
            }

            //Verify is a RaceTypeID was choosed.
            if (sigue)
            {
                try
                {   //If no race type choosed from combo box
                    aRaceIdSelectedInCombo = Convert.ToInt32(cbRaceTypes.SelectedItem.Value);
                    if (aRaceIdSelectedInCombo == 0)
                    {
                        sigue = false;
                        messageError = "Escoje un tipo de competicion de la lista desplegable.";
                    }
                }
                catch (Exception)
                {   //If something wrong written in combobox
                    sigue = false;
                    messageError = "El tipo de competición que has introducido es desconocido.<br /><br />Escoje uno de la lista desplegable.";
                }
            }

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Grabamos los datos en pantalla?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoSave()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotSave()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void DoNotSave()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Grabación Cancelada" });
        }

        [DirectMethod]
        public void DoSave()
        {
            bool sigue = true;
            string messageError = null;

            //Save if conditions are ok.
            if (sigue)
            {
                using (var db = new ClubSiteContext())
                {
                    Race aRace;
                    if (rUsed.Id == 0)
                    { //New Race
                        aRace = new Race();
                        aRace.Name = txbxName.Text;
                        aRace.Name = txbxName.Text;
                        aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
                        aRace.ImageURL = rUsed.ImageURL;
                        aRace.RaceTypeID = aRaceIdSelectedInCombo;
                        try
                        {
                            aRace.PartFem = Convert.ToInt16(txbxPartGenFem.Text);
                        }
                        catch (Exception)
                        {
                            aRace.PartFem = 0;
                        }
                        try
                        {
                            aRace.PartMasc = Convert.ToInt16(txbxPartGenMasc.Text);
                        }
                        catch (Exception)
                        {
                            aRace.PartMasc = 0;
                        }
                        Address anAddres = new Address(txbxStreet.Text, txbxNumber.Text, txbxCity.Text, txbxCountry.Text, txbxPostalCode.Text);
                        aRace.Address = anAddres;
                        aRace.Memo = txbxMemo.Text;
                        string aux = ReformatNumber(txbxLatitud.Text);
                        if (aux == null)
                            aRace.Latitud = 0;
                        else
                        {
                            aRace.Latitud = Convert.ToDouble(aux);
                        }

                        aux = ReformatNumber(txbxLongitud.Text);
                        if (aux == null)
                            aRace.Longitud = 0;
                        else
                        {
                            aRace.Longitud = Convert.ToDouble(aux);
                        }

                        db.Races.Add(aRace);
                        messageError = "Nueva competición grabada";
                    }
                    else
                    { //Update actual Race
                        aRace = (from races in db.Races
                                 where races.Id == rUsed.Id
                                 select races).FirstOrDefault();
                        if (aRace == null)
                        {
                            // The item wasn't found
                            ModelState.AddModelError("", String.Format("Competición con Id : {0} no encontrada", rUsed.Id));
                            X.Msg.Alert("Atención", "Competición no encontrada. Grabación de datos cancelada.").Show();
                            return;
                        }
                        aRace.Name = txbxName.Text;
                        aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
                        aRace.ImageURL = rUsed.ImageURL;
                        aRace.RaceTypeID = aRaceIdSelectedInCombo;
                        Address anAddres = new Address(txbxStreet.Text, txbxNumber.Text, txbxCity.Text, txbxCountry.Text, txbxPostalCode.Text);
                        aRace.Address = anAddres;
                        aRace.Memo = txbxMemo.Text;
                        string aux = ReformatNumber(txbxLatitud.Text);
                        if (aux == null)
                            aRace.Latitud = 0;
                        else
                        {
                            aRace.Latitud = Convert.ToDouble(aux);
                        }

                        aux = ReformatNumber(txbxLongitud.Text);
                        if (aux == null)
                            aRace.Longitud = 0;
                        else
                        {
                            aRace.Longitud = Convert.ToDouble(aux);
                        }
                        messageError = "Datos de competición actualizados";
                    }
                    db.SaveChanges();
                    LoadRaceInForm(aRace);  //To update the ID (identity file)                                  
                    rUsed.CopyRace(aRace);
                    oldRUsed.CopyRace(rUsed);
                    StoreGPRaces.DataBind();
                    X.Msg.Alert("Atención", messageError).Show();
                }
                btnBorrar.Enabled = true;
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskAddClubber()
        {
            bool sigue = true;
            string messageError = "";

            //Verify reace exists           
            if (txbxID.Text == "0")
            {
                sigue = false;
                messageError = "Grabe primero los datos de la carrera antes de añadir clubbers.";
            }

            if (sigue)
            {
                //Take clubber´s username 
                aMemberUserName = cbClubbers.SelectedItem.Value;
                if (aMemberUserName == null)
                {
                    messageError = "Seleccione ántes el clubber a añadir de la lista desplegable.";
                    sigue = false;
                }
            }

            if (sigue)
            {
                //Verify if clubber exist 
                messageError = "El ususario introducido en el desplegable no es un clubber válido.";
                sigue = VerifyIfClubberExist(aMemberUserName);
            }

            if (sigue)
            {

                X.Msg.Confirm("Atención", "¿Añadimos a " + aMemberUserName + " a la competición?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoAddClubber()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotAddClubber()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void DoNotAddClubber()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelado el añadir clubber" });
        }

        [DirectMethod]
        public void DoAddClubber()
        {
            bool sigue = true;
            string messageError = "";

            //Load data for username
            using (var db = new ClubSiteContext())
            {
                Member aMember = new Member();
                Race aRace = new Race();
                aMember = (from m in db.Members where m.UserName == aMemberUserName select m).FirstOrDefault();
                aRace = (from r in db.Races where r.Id == rUsed.Id select r).FirstOrDefault();

                //verify if member is in members list for race
                if (aRace.Members.Contains(aMember) == true)
                {
                    messageError = aMemberUserName + " ya está ese inscrito en la competición.";
                    sigue = false;
                }
                else
                {
                    try
                    {
                        aRace.Members.Add(aMember);
                        db.SaveChanges();
                        LoadDataInGridForMembersInRace();
                        X.Msg.Alert("Atención", "Se ha inscrito a " + aMemberUserName + " en la competición.").Show();
                    }
                    catch (Exception)
                    {
                        X.Msg.Alert("Atención", "Hubo un problema al añadir a " + aMemberUserName + "a la lista de participantes en la competición.").Show();
                    }
                }
            }


            if (!sigue)
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskDelClubber()
        {
            //Take clubber´s username from GridView
            CellSelectionModel sm = this.GPClubbersEnComp.GetSelectionModel() as CellSelectionModel;
            aMemberUserName = sm.SelectedCell.RecordID;


            X.Msg.Confirm("Atención", "¿Quitamos a " + aMemberUserName + " de la competición?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoDelClubber()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNotDelClubber()",
                    Text = "No"
                }
            }).Show();

        }

        [DirectMethod]
        public void DoNotDelClubber()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelado el quitar clubber" });
        }

        [DirectMethod]
        public void DoDelClubber()
        {
            bool sigue = true;
            string messageError = "";

            //Verify reace exists           
            if (txbxID.Text == "0")
            {
                sigue = false;
                messageError = "No hay clubbers que quitar.";
            }

            if (sigue)
            {
                if (aMemberUserName == null)
                {
                    messageError = "Seleccione un clubber de la tabla de participantes incluidos en la competición.";
                    sigue = false;
                }
            }

            if (sigue)
            {
                //Load data for username                
                using (var db = new ClubSiteContext())
                {
                    Member aMember = new Member();
                    Race aRace = new Race();
                    aMember = (from m in db.Members where m.UserName == aMemberUserName select m).FirstOrDefault();
                    aRace = (from r in db.Races where r.Id == rUsed.Id select r).FirstOrDefault();
                    try
                    {
                        aRace.Members.Remove(aMember);
                        db.SaveChanges();
                        LoadDataInGridForMembersInRace();
                        X.Msg.Alert("Atención", aMemberUserName + " quitad@ de la competición.").Show();
                    }
                    catch (Exception)
                    {
                        X.Msg.Alert("Atención", "Hubo un problema al quitar a " + aMemberUserName + " de la lista de participantes en la competición.").Show();
                    }

                }
            }

            if (!sigue)
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskDelAllClubbers()
        {
            bool sigue = true;

            if (rUsed.Id == 0)
            { //No Race selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay competiciones registradas.").Show();
                sigue = false;
            }

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Desea borrar todos los clubbers inscritos en la competición?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoDelAllClubbers()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotDelAllClubbers()",
                        Text = "No"
                    }
                }).Show();
            }
        }

        [DirectMethod]
        public void DoNotDelAllClubbers()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Se ha cancelado el borrado." });
        }

        [DirectMethod]
        public void DoDelAllClubbers()
        {
            //Del all races
            using (var db = new ClubSiteContext())
            {
                Race aRace = (from races in db.Races
                              where races.Id == rUsed.Id
                              select races).FirstOrDefault();
                if (aRace == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Competición con id : {0} no encontrada", rUsed.Id));
                    X.Msg.Alert("Atención", "Competición no encontrada. Borrado cancelado,").Show();
                    return;
                }
                aRace.Members.Clear();
                db.SaveChanges();
                LoadDataInGridForMembersInRace();
                X.Msg.Alert("Atención", "Clubbers inscritos en la carrera borrados.").Show();
            }

        }

        [DirectMethod]
        public void AskAddAG()
        {
            bool sigue = true;
            string messageError = "";

            //Verify reace exists           
            if (txbxID.Text == "0")
            {
                sigue = false;
                messageError = "Grabe primero los datos de la carrera antes de añadir grupos de edad.";
            }

            if (sigue)
            {
                //verify if exists age group name                
                if (txbxGEName.Text == "")
                {
                    messageError = "Introduzca un nombre de grupo de edad.";
                    sigue = false;
                }
            }

            if (sigue)
            {
                //verify if exists number of participants for group name                                
                try
                {
                    Convert.ToInt16(txbxGEPart.Text);
                }
                catch (Exception)
                {
                    messageError = "Introduzca el nº de participantes para el grupo de edad.";
                    sigue = false;
                }
            }

            if (sigue)
            {

                X.Msg.Confirm("Atención", "¿Añadimos " + txbxGEName.Text + " a los grupos de edad?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoAddAG()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotAddAG()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void DoAddAG()
        {
            //Load data for username
            using (var db = new ClubSiteContext())
            {
                try
                {
                    RaceAgeGroup aRaceAgeGroup = new RaceAgeGroup();
                    aRaceAgeGroup.Name = txbxGEName.Text;
                    aRaceAgeGroup.Part = Convert.ToInt16(txbxGEPart.Text);
                    aRaceAgeGroup.RaceID = rUsed.Id;
                    db.RaceAgeGroups.Add(aRaceAgeGroup);
                    db.SaveChanges();
                    LoadDataInGridForAgeGroups();
                    X.Msg.Alert("Atención", "Se ha añadido el grupo de edad " + txbxGEName.Text + " en la competición.").Show();
                }
                catch (Exception)
                {
                    X.Msg.Alert("Atención", "Hubo un problema al añadir el grupo de edad " + txbxGEName.Text + "a la competición.").Show();
                }
            }
        }

        [DirectMethod]
        public void DoNotAddAG()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelado el añadir grupo de edad" });
        }

        [DirectMethod]
        public void AskDelAG()
        {
            bool sigue = true;
            string message = "";
            string grupo = "";

            //Verify if exists age groups
            using (var db = new ClubSiteContext())
            {
                Int32 aListOfAG = (from ag in db.RaceAgeGroups where ag.RaceID == rUsed.Id select ag).Count();
                if (aListOfAG == 0)
                {
                    sigue = false;
                    message = "No hay grupos de edad para quitar.";
                }
            }               

            if (sigue)
            {
                CellSelectionModel sm = this.GPAgeGroupsEnComp.GetSelectionModel() as CellSelectionModel;
                Int32 aGAId = Convert.ToInt32(sm.SelectedCell.RecordID);
                using (var db = new ClubSiteContext()) 
                {
                    RaceAgeGroup aAG = (from ag in db.RaceAgeGroups where ag.Id == aGAId select ag).FirstOrDefault();
                    if (aAG == null)
                    {
                        sigue = false;
                        message="No se encontró el grupo de edad en la Base de datos.";
                    }
                    else
                    {
                        grupo=aAG.Name;
                    }
                }
            }

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Quitamos el grupo de edad " + grupo + " de los grupos de edad?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoDelAG()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotDelAG()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", message).Show();
            }
        }

        [DirectMethod]
        public void DoDelAG()
        {
            bool sigue= true;
            string grupo="";

            //Take age group rname from GridView
            CellSelectionModel sm = this.GPAgeGroupsEnComp.GetSelectionModel() as CellSelectionModel;
            Int32 aGAId = Convert.ToInt32(sm.SelectedCell.RecordID);

            using (var db = new ClubSiteContext())
            {
                RaceAgeGroup aAG = (from ag in db.RaceAgeGroups where ag.Id == aGAId select ag).FirstOrDefault();
                if (aAG == null)
                {
                    sigue = false;
                    X.Msg.Alert("Atención", "No se encontró el grupo de edad " + grupo + " de la competición.").Show();
                }
                else
                {
                    grupo = aAG.Name;
                }
            }

            if (sigue)
            {
                //Load data for age group                
                using (var db = new ClubSiteContext())
                {
                    RaceAgeGroup aAG = new RaceAgeGroup();
                    aAG = (from ag in db.RaceAgeGroups where ag.Id == aGAId select ag).FirstOrDefault();
                    if (aAG != null)
                    {
                        try
                        {
                            db.RaceAgeGroups.Remove(aAG);
                            db.SaveChanges();
                            LoadDataInGridForAgeGroups();
                            X.Msg.Alert("El grupo de edad", grupo + " ha sido quitado de la competición.").Show();
                        }
                        catch (Exception)
                        {
                            X.Msg.Alert("Atención", "Hubo un problema al quitar el grupo de edad " + grupo + " de la competición.").Show();
                        }
                    }

                }
            }
         
        }

        [DirectMethod]
        public void DoNotDelAG()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelado el borrado de grupo de edad" });
        }

        [DirectMethod]
        public void CalcTotalPart()
        {
            int num1 = 0;
            int num2 = 0;
            try
            {
                num1 = Convert.ToInt16(txbxPartGenFem.Text);
            }
            catch (Exception)
            {
                num1 = 0;
                txbxPartGenFem.Text = "0";
            }
            try
            {
                num2 = Convert.ToInt16(txbxPartGenMasc.Text);
            }
            catch (Exception)
            {
                num2 = 0;
                txbxPartGenMasc.Text = "0";
            }
            txbxPartGenTot.Text = Convert.ToString(num1 + num2);
        }

        [DirectMethod]
        public void AskDelAllAG()
        {
            bool sigue = true;
            string message = "";

            //Verify if exists age groups
            using (var db = new ClubSiteContext())
            {
                Int32 aListOfAG = (from ag in db.RaceAgeGroups where ag.RaceID == rUsed.Id select ag).Count();
                if (aListOfAG == 0)
                {
                    sigue = false;
                    message = "No hay grupos de edad para quitar.";
                }
            }            

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Quitamos todos los grupo de edad de la competición?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoDelAllAG()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotDelAllAG()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", message).Show();
            }
        }

        [DirectMethod]
        public void DoDelAllAG()
        {
            bool sigue = true;
            string grupo = "";
            
            if (sigue)
            {
                //Load data for age group                
                using (var db = new ClubSiteContext())
                {                    
                    var aListOfAG = from ag in db.RaceAgeGroups where ag.RaceID == rUsed.Id select ag;
                    if (aListOfAG != null)
                    {
                        try
                        {
                            foreach (RaceAgeGroup ag in aListOfAG.ToList())
                            {
                                db.RaceAgeGroups.Remove(ag);
                            }
                            db.SaveChanges();
                            LoadDataInGridForAgeGroups();
                            X.Msg.Alert("Atención","Todos los grupos de edad han sido quitados de la competición.").Show();
                        }
                        catch (Exception)
                        {
                            X.Msg.Alert("Atención", "Hubo un problema al quitar el grupo de edad " + grupo + " de la competición.").Show();
                        }
                    }

                }
            }

        }

        [DirectMethod]
        public void DoNotDelAllAG()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelado el borrado de todos los grupos de edad" });
        }

        public string ReformatNumber(string aString)
        {
            string result = null;
            int pointPos = aString.IndexOf('.');
            if (pointPos != -1)
            {
                System.Text.StringBuilder strBuild = new System.Text.StringBuilder(aString);
                strBuild[pointPos] = ',';
                result = strBuild.ToString();
            }
            return result;
        }
    }
}