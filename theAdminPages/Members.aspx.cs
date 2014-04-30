using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Security;
using Ext.Net;

namespace ClubSite.AdminPages
{
    public partial class Members : System.Web.UI.Page
    {
        static string actualUserName;
        static int actualRaceId;
        static Member memberUsed;
        static Member oldMemberUsed;
        static bool newNumber = false;
        static bool newImage = false;
        static bool newNImage = false;
      
        private void LoadMemberInForm(Member aMember)
        {
            actualUserName = aMember.UserName;
            txbxUserName.Text = aMember.UserName;
            txbxRegDate.Text = aMember.RegDate.ToShortDateString();
            txbxClubberNumber.Text = aMember.Number;
            txbxDNI.Text = aMember.DNI;
            txbxFirstName.Text = aMember.FirstName;
            txbxSecondName.Text = aMember.SecondName;
            txbxBdate.Text = aMember.BirthDate.ToString();
            imgImage.ImageUrl = aMember.ImageURL;
            FileUploadImage.Text = "";
            imgNImage.ImageUrl = aMember.NImageURL;
            FileUploadNumber.Text = "";
            chbxFederated.Checked = aMember.Federated;
            chBxActiveUser.Checked = aMember.State;
            chbxVisible.Checked = aMember.Visible;
            txbxBlogURL.Text = aMember.BlogURL;
            txbxEMail.Text = aMember.EMail;
            txbxMobile.Text = aMember.Mobile;
            txbxTlf.Text = aMember.Tlf;
            if (aMember.Address == null)
            {
                txbxStreet.Text = "";
                txbxNumber.Text = "";
                txbxCity.Text = "";
                txbxCountry.Text = "";
                txbxPostalCode.Text = "";
            }
            else
            {
                txbxStreet.Text = aMember.Address.Street;
                txbxNumber.Text = aMember.Address.Number;
                txbxCity.Text = aMember.Address.City;
                txbxCountry.Text = aMember.Address.Country;
                txbxPostalCode.Text = aMember.Address.PostalCode;
            }
            txbxMemo.Text = aMember.Memo;

            //Load data for races for the clubber selected
            LoadDataInGridForRacesForClubber();

            FileUploadNumber.Reset();
            FileUploadImage.Reset();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                memberUsed = new Member();
                oldMemberUsed = new Member();
                newNumber = false;
                newImage = false;
                newNImage = false;
                using (var db = new ClubSiteContext())
                {
                    memberUsed = (from members in db.Members
                                  orderby members.UserName
                                  select members).FirstOrDefault();

                    if (memberUsed == null)
                    {
                        actualUserName = "";
                        Notification.Show(new NotificationConfig { Title = "Atención", Icon = Icon.Error, Html = "No hay ningún usuario registrado en la Base de datos. Vaya al formulario de registro para crear nuevos usuarios." });
                    }
                    else
                    {
                        actualUserName = memberUsed.UserName;

                        //Load Dates
                        DateTime fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                        DateTime toDate = new DateTime(DateTime.Now.Year, 12, 31);
                        dtfFromDate.SelectedDate = fromDate;
                        dtfToDate.SelectedDate = toDate;

                        //Load data for Races combobox
                        LoadDataInRacesCombo();

                        //Load data for races for the clubber selected
                        LoadDataInGridForRacesForClubber();
                    }
                    LoadMemberInForm(memberUsed);
                    oldMemberUsed.CopyMember(memberUsed);
                }
            }
        }       

        [DirectMethod]
        public void AskNew()
        {
            X.Msg.Confirm("Atención", "¿Desea crear un nuevo Clubber?", new MessageBoxButtonsConfig
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
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la creación de nuevo clubber" });
        }

        [DirectMethod]
        public void DoNew()
        {
            oldMemberUsed.CopyMember(memberUsed);
            memberUsed.ClearMember();            
            imgNImage.ImageUrl = null;
            imgImage.ImageUrl = null;
            FileUploadImage.Reset();
            FileUploadNumber.Reset();
            LoadMemberInForm(memberUsed);            
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Introduzca datos del nuevo clubber" });
        }

        [DirectMethod]
        public void AskCancel()
        {
            X.Msg.Confirm("Atención", "¿Desea cancelar la edición del clubber actual?", new MessageBoxButtonsConfig
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
            if (newNumber)
            {
                if (System.IO.File.Exists(Server.MapPath(imgNImage.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgNImage.ImageUrl));

            }
            if (newImage)
            {
                if (System.IO.File.Exists(Server.MapPath(imgImage.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgImage.ImageUrl));
            }
            memberUsed.CopyMember(oldMemberUsed);
            LoadMemberInForm(memberUsed);
            newNumber = false;
            newImage = false;
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la edición" });
        }

        [DirectMethod]
        public void AskDel()
        {
            bool sigue = true;
            string messageError = null;

            if ((actualUserName == "") || (actualUserName == null))
            { //No member selected
                sigue = false;
                messageError = "No hay datos de clubbers. No se puede borrar nada.";
            }

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Desea borrar al clubber "+ actualUserName +" ?", new MessageBoxButtonsConfig
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
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void DoNotDel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Se ha cancelado el borrado." });
        }

        [DirectMethod]
        public void DoDel()
        {
            //1-Delete user in Member table in ClubSite.mdf DB
            using (var db = new ClubSiteContext())
            {
                //Delete the user
                var aClubberToDelete = (from c in db.Members
                                        where c.UserName == actualUserName
                                        select c).Single();
                db.Members.Remove(aClubberToDelete);
                db.SaveChanges();
                //Delete de Image files for the user
                if (System.IO.File.Exists(Server.MapPath(imgNImage.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgNImage.ImageUrl));
                if (System.IO.File.Exists(Server.MapPath(imgImage.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgImage.ImageUrl));
                Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Usuario "+ actualUserName +" borrado correctamente." });
            }

            //2-Delete user in Membership and Users tables in ClubSiteBDDefault DB
            Membership.DeleteUser(actualUserName);

            //3-Load data for the first member into the form.
            using (var db = new ClubSiteContext())
            {
                var aMember = (from members in db.Members
                               orderby members.UserName
                               select members).FirstOrDefault();

                if (aMember == null)
                {
                    actualUserName = "";
                    memberUsed = new Member();
                    LoadMemberInForm(memberUsed);
                    Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Ya no hay ningún usuario registrado. Para crear nuevos usuarios vaya al formulario de registro." });
                }
                else
                {
                    LoadMemberInForm(aMember);
                    memberUsed.CopyMember(aMember);
                }
                oldMemberUsed.CopyMember(memberUsed);
            }
            //4-Refresh the GridView
            GPClubbers.DataBind();
        }

        [DirectMethod]
        public void AskSave()
        {
            bool sigue = true;
            string messageError = null;

            actualUserName = txbxUserName.Text;
            if ((actualUserName == "") || (actualUserName == null))
            { //Missing UserName
                sigue = false;
                messageError = "Falta el UserName. Grabación cancelada.";
                txbxUserName.Focus();
            }

            if (sigue)
            {
                if (txbxFirstName.Text == "")
                {
                    sigue = false;
                    messageError = "Falta el Nombre del ususario. Grabación cancelada.";
                    txbxFirstName.Focus();
                }
            }

            if (sigue)
            {
                if (txbxSecondName.Text == "")
                {
                    sigue = false;
                    messageError = "Faltan los apellidos del usuario. Grabación cancelada.";
                    txbxSecondName.Focus();
                }
            }

            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Grabamos la ficha para el usuario " + actualUserName + " ?", new MessageBoxButtonsConfig
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
            bool nuevo = false;
            string messageError = null;


            //Save if conditions are ok.
            if (sigue)
            {
                //Update actual member
                actualUserName = txbxUserName.Text;
                using (var db = new ClubSiteContext())
                {
                    Member aMember = (from members in db.Members
                                      where members.UserName == actualUserName
                                      select members).FirstOrDefault();
                    if (aMember == null)
                    { //New User
                        aMember = new Member();
                        aMember.UserName = actualUserName;
                        nuevo = true;
                    }
                    try
                    {
                        aMember.FirstName = txbxFirstName.Text;
                        aMember.SecondName = txbxSecondName.Text;
                        aMember.BlogURL = txbxBlogURL.Text;
                        aMember.Memo = txbxMemo.Text;
                        aMember.DNI = txbxDNI.Text;                        
                        if (txbxBdate.Value.ToString() == "01/01/0001 0:00:00")
                        {
                            aMember.BirthDate = null;
                        }
                        else
                        {
                            try
                            {
                                aMember.BirthDate = Convert.ToDateTime(txbxBdate.Text);
                            }
                            catch
                            {
                                aMember.BirthDate = null;
                            }
                        }
                        aMember.Federated = chbxFederated.Checked;
                        aMember.State = chBxActiveUser.Checked;
                        aMember.Visible = chbxVisible.Checked;
                        if (FileUploadNumber.HasFile) 
                        {
                            aMember.NImageURL = "../Images/Clubbers/" + FileUploadNumber.FileName; //imgNImage.ImageUrl;
                        }
                        else
                        {
                            aMember.NImageURL = memberUsed.NImageURL;
                        }
                        if (FileUploadImage.HasFile)
                        {
                            aMember.ImageURL = "../Images/Clubbers/" + FileUploadImage.FileName; //imgImage.ImageUrl;
                        }
                        else
                        {
                            aMember.ImageURL = memberUsed.ImageURL;
                        }                        
                        aMember.Tlf = txbxTlf.Text;
                        aMember.Mobile = txbxMobile.Text;
                        aMember.EMail = txbxEMail.Text;
                        if (nuevo)
                        {
                            aMember.Address = new Address();
                        }
                        aMember.Address.Street = txbxStreet.Text;
                        aMember.Address.Number = txbxNumber.Text;
                        aMember.Address.City = txbxCity.Text;
                        aMember.Address.Country = txbxCountry.Text;
                        aMember.Address.PostalCode = txbxPostalCode.Text;
                        aMember.Number = txbxClubberNumber.Text;
                        if (nuevo)
                        {
                            db.Members.Add(aMember);
                        }
                        db.SaveChanges();
                        memberUsed.CopyMember(aMember);
                        oldMemberUsed.CopyMember(aMember);
                        Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Datos del usuario "+ actualUserName +" grabados" });

                    }
                    catch (Exception)
                    {
                        sigue = false;
                        messageError = " No se grabaron los datos, se produjo un error al acceder a la base";
                    }
                    GPClubbers.DataBind();
                    newNumber = false;
                    newImage = false;
                }
            }
            if (!sigue)
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskAddRace()
        {
            bool sigue = true;
            string messageError = "";

            //Verify Clubbers exists           
            if (txbxUserName.Text == "")
            {
                sigue = false;
                messageError = "Grabe primero los datos del clubber antes de añadir competiciones.";
            }

            if (sigue)
            {
                //Take race id
                try
                {
                    actualRaceId = Convert.ToInt32(cbRaces.SelectedItem.Value);
                }
                catch (Exception)
                {
                    messageError = "Seleccione ántes la competición a añadir de la lista desplegable.";
                    sigue = false;
                }
            }

            if (sigue)
            {
                //Verify if clubber exist 
                messageError = "La competición introducido en el desplegable no es un clubber válido.";
                sigue = VerifyIfRaceExist(actualRaceId);
            }

            if (sigue)
            {

                X.Msg.Confirm("Atención", "¿Añadimos la competición a la lista de competiciones de " + memberUsed.UserName + " ?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoAddRace()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotAddRace()",
                        Text = "No"
                    }
                }).Show();
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        private bool VerifyIfRaceExist(int actualRaceId)
        {
            bool exist = false;
            using (var db = new ClubSiteContext())
            {
                var item = (from r in db.Races where r.Id == actualRaceId select r).FirstOrDefault();
                if (item != null) exist = true;
            }
            return exist;
        }

        [DirectMethod]
        public void DoNotAddRace()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Operación cancelada." });
        }

        [DirectMethod]
        public void DoAddRace()
        {
            bool sigue = true;
            string messageError = "";

            //Load data for Race/Clubber
            using (var db = new ClubSiteContext())
            {
                Member aMember = new Member();
                Race aRace = new Race();
                aMember = (from m in db.Members where m.UserName == memberUsed.UserName select m).FirstOrDefault();
                aRace = (from r in db.Races where r.Id == actualRaceId select r).FirstOrDefault();

                //verify if member is in members list for race
                if (aRace.Members.Contains(aMember) == true)
                {
                    messageError = memberUsed.UserName + " ya esta inscrit@ en esa competición.";
                    sigue = false;
                }
                else
                {
                    try
                    {
                        aRace.Members.Add(aMember);
                        db.SaveChanges();
                        LoadDataInGridForRacesForClubber();
                        X.Msg.Alert("Atención", "Se ha inscrito a " + memberUsed.UserName + " en la competición.").Show();
                    }
                    catch (Exception)
                    {
                        X.Msg.Alert("Atención", "Hubo un problema al añadir a " + memberUsed.UserName + "a la lista de participantes en la competición.").Show();
                    }
                }
            }


            if (!sigue)
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskDelRace()
        {
            bool sigue = true;

            //Take RaceID from GridView
            CellSelectionModel sm = this.GPRacesForClubber.GetSelectionModel() as CellSelectionModel;

            try
            {
                actualRaceId = Convert.ToInt32(sm.SelectedCell.RecordID);
            }
            catch (Exception)
            {
                Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "No se encuentra la competición indicada, hubo algún problema." });
            }


            if (sigue)
            {
                X.Msg.Confirm("Atención", "¿Quitamos a " + memberUsed.UserName + " de la competición?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoDelRace()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotDelRace()",
                        Text = "No"
                    }
                }).Show();
            }
        }

        [DirectMethod]
        public void DoNotDelRace()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Operación cancelada" });
        }

        [DirectMethod]
        public void DoDelRace()
        {
            bool sigue = true;
            string messageError = "";

            //Verify race exists           
            if (txbxUserName.Text == "")
            {
                sigue = false;
                messageError = "No hay competiciones que quitar.";
            }

            if (sigue)
            {
                if (actualRaceId == 0)
                {
                    messageError = "Seleccione una competición para quitar de la tabla.";
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
                    aMember = (from m in db.Members where m.UserName == memberUsed.UserName select m).FirstOrDefault();
                    aRace = (from r in db.Races where r.Id == actualRaceId select r).FirstOrDefault();
                    try
                    {
                        aRace.Members.Remove(aMember);
                        db.SaveChanges();
                        LoadDataInGridForRacesForClubber();
                        X.Msg.Alert("Atención", memberUsed.UserName + " quitad@ de la competición.").Show();
                    }
                    catch (Exception)
                    {
                        X.Msg.Alert("Atención", "Hubo un problema al quitar a " + memberUsed.UserName + " de la competición seleccionada.").Show();
                    }

                }
            }

            if (!sigue)
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        [DirectMethod]
        public void AskDelAllRaces()
        {
            bool sigue = true;

            if (memberUsed.UserName == null)
            { //No Race selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay clubbers registrados.").Show();
                sigue = false;
            }

            if (sigue)
            {
                DateTime fromDate = dtfFromDate.SelectedDate;
                DateTime toDate = dtfToDate.SelectedDate;
                X.Msg.Confirm("Atención", "¿Desea borrar todos las competiciones en las que está inscrito " + memberUsed.UserName +
                                          " entre el " + fromDate.ToShortDateString() + " y el " + toDate.ToShortDateString() + "?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoDelAllRaces()",
                        Text = "Si"
                    }
                    ,
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNotDelAllRaces()",
                        Text = "No"
                    }
                }).Show();
            }
        }

        [DirectMethod]
        public void DoNotDelAllRaces()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Se ha cancelado el borrado." });
        }

        [DirectMethod]
        public void DoDelAllRaces()
        {
            //Del all races between fromDate and toDate
            DateTime fromDate = dtfFromDate.SelectedDate;
            DateTime toDate = dtfToDate.SelectedDate;
            using (var db = new ClubSiteContext())
            {
                Member aMember = (from m in db.Members
                                  where m.UserName == memberUsed.UserName
                                  select m).FirstOrDefault();
                if (aMember == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Clubber : {0} no encontrada", memberUsed.UserName));
                    X.Msg.Alert("Atención", "Clubber no encontrado. Borrado de competiciones cancelado,").Show();
                    return;
                }

                var dataToRemove = from r in aMember.Races where r.RaceDate >= fromDate && r.RaceDate <= toDate select r;
                foreach (Race aRaceToRemove in dataToRemove.ToList())
                {
                    aMember.Races.Remove(aRaceToRemove);
                }
                db.SaveChanges();
                LoadDataInGridForRacesForClubber();
                X.Msg.Alert("Atención", "Todas las competiciones del clubber entre el " + fromDate.ToShortDateString() +
                                        " y el " + toDate.ToShortDateString() + "han sido borradas.").Show();
            }

        }

        protected void UploadImgClick(object sender, DirectEventArgs e)
        {
            string tpl = "Subida la imagen: {0}<br/>Size: {1} bytes";

            if (this.FileUploadImage.HasFile)
            {
                string virtualFolder = "../Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUploadImage.FileName; // Guid.NewGuid().ToString();
                //string extension = System.IO.Path.GetExtension(FileULogo.FileName);
                FileUploadImage.PostedFile.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgImage.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newImage = true;
                memberUsed.ImageURL = imgImage.ImageUrl;                

                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Terminado",
                    Message = string.Format(tpl, this.FileUploadImage.PostedFile.FileName, this.FileUploadImage.PostedFile.ContentLength)
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
        }
        protected void UploadNImgClick(object sender, DirectEventArgs e)
        {
            string tpl = "Subida la imagen: {0}<br/>Size: {1} bytes";

            if (this.FileUploadNumber.HasFile)
            {
                string virtualFolder = "../Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUploadNumber.FileName; // Guid.NewGuid().ToString();
                //string extension = System.IO.Path.GetExtension(FileULogo.FileName);
                FileUploadNumber.PostedFile.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgNImage.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newNImage = true;
                memberUsed.NImageURL = imgNImage.ImageUrl;                

                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Terminado",
                    Message = string.Format(tpl, this.FileUploadNumber.PostedFile.FileName, this.FileUploadNumber.PostedFile.ContentLength)
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
        }
        [DirectMethod]
        public void BorrarImgClick()
        {
            X.Msg.Confirm("Atención", @"Va a quitar la imagen selecionada.<br/>
                                        <br/>
                                        ¿Desea borrar el fichero tambien del servidor?<br/>
                                        Tenga en cuenta que la imagen no esté usada por otro sponsor.", new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = "App.direct.BorradoCompletoImg()",
                            Text = "Si"
                        }
                                                                                                          ,
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "App.direct.BorradoNormalImg()",
                            Text = "No"
                        }
                    }).Show();
        }
        [DirectMethod]
        public void BorrarNImgClick()
        {
            X.Msg.Confirm("Atención", @"Va a quitar la imagen selecionada.<br/>
                                        <br/>
                                        ¿Desea borrar el fichero tambien del servidor?<br/>
                                        Tenga en cuenta que la imagen no esté usada por otro sponsor.", new MessageBoxButtonsConfig

                    {
                        Yes = new MessageBoxButtonConfig
                            {
                                Handler = "App.direct.BorradoCompletoNImg()",
                                Text = "Si"
                            }
                                                                                                                                                                                            ,
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "App.direct.BorradoNormalNImg()",
                            Text = "No"
                        }
                    }).Show();
        }
        [DirectMethod]
        public void BorradoCompletoImg()
        {
            System.IO.File.Delete(Server.MapPath(memberUsed.ImageURL));
            imgImage.ImageUrl = null;
            memberUsed.ImageURL = null;
            this.FileUploadImage.Reset();
        }
        [DirectMethod]
        public void BorradoNormalImg()
        {
            imgImage.ImageUrl = null;
            memberUsed.ImageURL = null;
            this.FileUploadImage.Reset();
        }
        [DirectMethod]
        public void BorradoCompletoNImg()
        {
            System.IO.File.Delete(Server.MapPath(memberUsed.NImageURL));
            imgNImage.ImageUrl = null;
            memberUsed.NImageURL = null;
            this.FileUploadNumber.Reset();
        }
        [DirectMethod]
        public void BorradoNormalNImg()
        {
            imgNImage.ImageUrl = null;
            memberUsed.NImageURL = null;
            this.FileUploadNumber.Reset();
        }

        [DirectMethod]
        public void ChangedADate()
        {
            LoadDataInRacesCombo();
        }

        protected void LoadDataInRacesCombo()
        {
            using (var db = new ClubSiteContext())
            {
                DateTime fromDate = dtfFromDate.SelectedDate;
                DateTime toDate = dtfToDate.SelectedDate;
                Store store = this.cbRaces.GetStore();
                store.DataSource = from r in db.Races
                                   join rt in db.RaceTypes on r.RaceTypeId equals rt.RaceTypeID
                                   join s in db.Sports on rt.SportID equals s.SportID
                                   where r.RaceDate >= fromDate && r.RaceDate <= toDate
                                   orderby s.Name, rt.Name, r.Name
                                   select new { r.Id, Name = r.Name + " (" + s.Name + " " + rt.Name + ")" };
                store.DataBind();
            }
        }
        protected void LoadDataInGridForRacesForClubber()
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.GPRacesForClubber.GetStore();
                var aMember = (from m in db.Members
                               where m.UserName == memberUsed.UserName
                               select m).FirstOrDefault();
                if (aMember != null)
                {
                    store.DataSource = from r in aMember.Races
                                       orderby r.RaceDate
                                       select new { r.Id, r.Name, RDate = r.RaceDate, SportName = r.RaceType.Sport.Name, RaceTypeName = r.RaceType.Name };
                }
                else
                {
                    store.DataSource = new List<Races>();
                }
                store.DataBind();
            }
        }
        protected void GPRacesForClubber_Click(object sender, EventArgs e)
        {
        }
        protected void StoreGPRacesForClubber_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.GPRacesForClubber.GetStore();
                var aMember = (from m in db.Members
                               where m.UserName == memberUsed.UserName
                               select m).FirstOrDefault();
                if (aMember != null)
                {
                    store.DataSource = from r in aMember.Races
                                       orderby r.RaceDate
                                       select new { r.Id, r.Name, RDate = r.RaceDate, SportName = r.RaceType.Sport.Name, RaceTypeName = r.RaceType.Name };
                    store.DataBind();
                }
            }
        }
        protected void StoreCbRaces_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                DateTime fromDate = dtfFromDate.SelectedDate;
                DateTime toDate = dtfToDate.SelectedDate;
                Store store = this.cbRaces.GetStore();
                store.DataSource = from r in db.Races
                                   join rt in db.RaceTypes on r.RaceTypeId equals rt.RaceTypeID
                                   join s in db.Sports on rt.SportID equals s.SportID
                                   where r.RaceDate >= fromDate && r.RaceDate <= toDate
                                   orderby s.Name, rt.Name, r.Name
                                   select new { r.Id, Name = r.Name + " (" + s.Name + " " + rt.Name + ")" };
                store.DataBind();
            }
        }
        protected void GVClubbers_Click(object sender, EventArgs e)
        {
            try
            {
                CellSelectionModel sm = this.GPClubbers.GetSelectionModel() as CellSelectionModel;
                string actualRId = sm.SelectedCell.RecordID;
                using (var db = new ClubSiteContext())
                {
                    memberUsed = (from m in db.Members
                                  where m.UserName == actualRId
                                  select m).FirstOrDefault();

                    if (memberUsed == null)
                        X.Msg.Alert("Atención", "No hay ningun clubber registrada en la Base de datos.").Show();
                    oldMemberUsed.CopyPerson(memberUsed);

                    //Loads model object data into form
                    LoadMemberInForm(memberUsed);                    
                }
            }
            catch (Exception) { }
        }
    }
}