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
        static Race oldRUsed;
        static string aMemberUserName = null;
        static Int32 aRaceIdSelectedInCombo = 0;

        private Race LoadRaceFromForm()
        {            
            Int32 anId = Convert.ToInt32(txbxID.Text);
            using (ClubSiteContext db = new ClubSiteContext())
            {
                Race aRace = (from r in db.Races where r.Id==anId select r).FirstOrDefault();
                return aRace;
            }                        
        }
        private void LoadRaceInForm(Race aRace)
        {
            txbxID.Text = Convert.ToString(aRace.Id);
            txbxName.Text = aRace.Name;
            txbxDate.Text = aRace.RaceDate.ToShortDateString();

            //Load data for RaceType combo
            if (aRace.RaceTypeId == 0)
                cbRaceTypes.Value = "";
            else
            {
                object aRaceTypeID = aRace.RaceTypeId;
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


            //Load Members taken part in actual race   
            LoadDataInGridForMembersInRace();

            //Select members taken part in race with ID aRace.Id, and populate lbClubbersTakenPart
            //loadClubbersTakenPart();

            //Search points asigned to race an put on txbxPoints
            if (aRace.RaceTypeId == 0)
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
                        aRace.RaceTypeId = aRaceIdSelectedInCombo;
                        Address anAddres = new Address(txbxStreet.Text, txbxNumber.Text, txbxCity.Text, txbxCountry.Text, txbxPostalCode.Text);
                        aRace.Address = anAddres;
                        aRace.Memo = txbxMemo.Text;
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
                            X.Msg.Alert("Atención","Competición no encontrada. Grabación de datos cancelada.").Show();
                            return;
                        }
                        aRace.Name = txbxName.Text;
                        aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
                        aRace.RaceTypeId = aRaceIdSelectedInCombo;
                        Address anAddres = new Address(txbxStreet.Text, txbxNumber.Text, txbxCity.Text, txbxCountry.Text, txbxPostalCode.Text);
                        aRace.Address = anAddres;
                        aRace.Memo = txbxMemo.Text;
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
                        X.Msg.Alert("Atención", "Hubo un problema al añadir a " + aMemberUserName +"a la lista de participantes en la competición.").Show();
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
            bool sigue = true;

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
    }
}