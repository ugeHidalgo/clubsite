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
    public partial class Sponsors : System.Web.UI.Page
    {
        static int sponsorUsedId;
        static Sponsor sponsorUsed;
        static Sponsor oldSponsorUsed;
        static bool newLogo = false;
        static bool newImage = false;

        private void LoadSponsorInForm(Sponsor aSponsor)
        {
            sponsorUsedId = aSponsor.SponsorId;
            imgLogo.ImageUrl = aSponsor.LogoURL;
            imgLogo.AlternateText = "(Sin Logo)";
            FileULogo.Text = "";
            imgImage.ImageUrl = aSponsor.ImageURL;
            imgImage.AlternateText = "(Sin imagen)";
            FileUImg.Text = "";
            txbxId.Text = sponsorUsedId.ToString();
            txbxNombre.Text = aSponsor.Nombre;
            txbxContacto.Text = aSponsor.ContactPerson;
            txbxRegDate.Text = aSponsor.RegDate.ToShortDateString();
            chbcActivo.Checked = aSponsor.Activo;
            try
            {
                txbxAportInicial.Text = aSponsor.AportInicial.ToString();
            }
            catch (Exception)
            {
                txbxAportInicial.Text = "";
            }
            try
            {
                txbxAportRecibida.Text = aSponsor.AportRecibida.ToString();
            }
            catch (Exception)
            {
                txbxAportRecibida.Text = "";
            }
            txbxCondOfertadas.Text = aSponsor.CondOfertadas;
            txbxBlogURL.Text = aSponsor.WebURL;
            txbxEMail.Text = aSponsor.EMail;
            txbxMobile.Text = aSponsor.Mobile;
            txbxTlf.Text = aSponsor.Tlf;
            txbxMemo.Text = aSponsor.Memo;
            if (aSponsor.Address == null)
            {
                txbxStreet.Text = null;
                txbxCity.Text = null;
                txbxNumber.Text = null;
                txbxCountry.Text = null;
                txbxPostalCode.Text = null;
            }
            else
            {
                txbxStreet.Text = aSponsor.Address.Street;
                txbxCity.Text = aSponsor.Address.City;
                txbxNumber.Text = aSponsor.Address.Number;
                txbxCountry.Text = aSponsor.Address.Country;
                txbxPostalCode.Text = aSponsor.Address.PostalCode;
            }
            ////To avoid problems with the , and . in decimal numbers
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            txbxLatitud.Text = Convert.ToString(aSponsor.Latitud, culture );
            txbxLongitud.Text = Convert.ToString(aSponsor.Longitud, culture);            
        }
        private Sponsor LoadSponsorFromForm()
        {
            Sponsor aSponsor = new Sponsor();
            aSponsor.SponsorId = Convert.ToInt16(txbxId.Text);
            aSponsor.LogoURL = sponsorUsed.LogoURL;
            aSponsor.ImageURL = sponsorUsed.ImageURL;
            aSponsor.Nombre = txbxNombre.Text;
            aSponsor.ContactPerson = txbxContacto.Text;
            aSponsor.RegDate = Convert.ToDateTime(txbxRegDate.Text);
            aSponsor.Activo = chbcActivo.Checked;
            try
            {
                aSponsor.AportInicial = Convert.ToDecimal(txbxAportInicial.Text);
            }
            catch (Exception)
            {
                aSponsor.AportInicial = 0;
            }
            try
            {
                aSponsor.AportRecibida = Convert.ToDecimal(txbxAportRecibida.Text);
            }
            catch (Exception)
            {
                aSponsor.AportRecibida = 0;
            }
            aSponsor.CondOfertadas = txbxCondOfertadas.Text;
            aSponsor.WebURL = txbxBlogURL.Text;
            aSponsor.EMail = txbxEMail.Text;
            aSponsor.Mobile = txbxMobile.Text;
            aSponsor.Tlf = txbxTlf.Text;
            aSponsor.Memo = txbxMemo.Text;
            aSponsor.Address.Street = txbxStreet.Text;
            aSponsor.Address.City = txbxCity.Text;
            aSponsor.Address.Number = txbxNumber.Text;
            aSponsor.Address.Country = txbxCountry.Text;
            aSponsor.Address.PostalCode = txbxPostalCode.Text;
            string aux = ReformatNumber(txbxLatitud.Text);
            if (aux == null)
                aSponsor.Latitud = 0;
            else
            {
                aSponsor.Latitud = Convert.ToDouble(aux);
            }

            aux = ReformatNumber(txbxLongitud.Text);
            if (aux == null)
                aSponsor.Longitud = 0;
            else
            {
                aSponsor.Longitud = Convert.ToDouble(aux);
            }            
            return aSponsor;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sponsorUsed = new Sponsor();
                oldSponsorUsed = new Sponsor();
                using (var db = new ClubSiteContext())
                {
                    sponsorUsed = (from sponsors in db.Sponsors
                                   orderby sponsors.Nombre
                                   select sponsors).FirstOrDefault();

                    if (sponsorUsed == null)
                    {
                        sponsorUsed = new Sponsor();
                        Response.Write("<script>alert('No hay ningún Sponsor registrado en la Base de datos.')</script>");
                    }
                    oldSponsorUsed.CopySponsor(sponsorUsed);
                    LoadSponsorInForm(sponsorUsed);
                }
            }
        }

        protected void GPSponsors_CellClick(object sender, EventArgs e)
        {   //Click a Sponsor in grid and show data in edit boxes
            try
            {
                CellSelectionModel sm = this.GPSponsors.GetSelectionModel() as CellSelectionModel;
                Int32 actualSId = Convert.ToInt32(sm.SelectedCell.RecordID);

                //Search the Sponsor and load into model object.
                using (var db = new ClubSiteContext())
                {
                    sponsorUsed = (from sponsors in db.Sponsors
                                   orderby sponsors.Nombre
                                   where sponsors.SponsorId == actualSId
                                   select sponsors).FirstOrDefault();

                    if (sponsorUsed == null)
                        X.Msg.Alert("Atención", "No hay ningún sponsor registrado en la Base de datos.").Show();
                    oldSponsorUsed.CopySponsor(sponsorUsed);

                    //Loads model object data into form
                    LoadSponsorInForm(sponsorUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        protected void UploadLogoClick(object sender, DirectEventArgs e)
        {
            string tpl = "Subida la imagen: {0}<br/>Size: {1} bytes";

            if (this.FileULogo.HasFile)
            {
                string virtualFolder = "../Images/Sponsors/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileULogo.FileName; // Guid.NewGuid().ToString();
                //string extension = System.IO.Path.GetExtension(FileULogo.FileName);
                FileULogo.PostedFile.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgLogo.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newLogo = true;
                sponsorUsed.LogoURL = imgLogo.ImageUrl;

                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Terminado",
                    Message = string.Format(tpl, this.FileULogo.PostedFile.FileName, this.FileULogo.PostedFile.ContentLength)
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
            this.FileULogo.Reset();
        }
        [DirectMethod]
        public void BorrarLogoClick()
        {
            X.Msg.Confirm("Atención", @"Va a quitar la imagen selecionada.<br/>
                                        <br/>
                                        ¿Desea borrar el fichero tambien del servidor?<br/>
                                        Tenga en cuenta que la imagen no esté usada por otro sponsor.", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.BorradoCompleto()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.BorradoNormal()",
                    Text = "No"
                }
            }).Show();
        }
        [DirectMethod]
        public void BorradoCompleto()
        {
            System.IO.File.Delete(Server.MapPath(sponsorUsed.LogoURL));
            imgLogo.ImageUrl = null;
            sponsorUsed.LogoURL = null;
            this.FileULogo.Reset();
        }
        [DirectMethod]
        public void BorradoNormal()
        {
            imgLogo.ImageUrl = null;
            sponsorUsed.LogoURL = null;
            this.FileULogo.Reset();
        }
        protected void UploadImgClick(object sender, DirectEventArgs e)
        {
            string tpl = "Subida la imagen: {0}<br/>Size: {1} bytes";

            if (this.FileUImg.HasFile)
            {
                string virtualFolder = "../Images/Sponsors/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUImg.FileName; //Guid.NewGuid().ToString();
                //string extension = System.IO.Path.GetExtension(FileUImg.FileName);
                FileUImg.PostedFile.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgImage.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newImage = true;
                sponsorUsed.ImageURL = imgImage.ImageUrl;
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
            System.IO.File.Delete(Server.MapPath(sponsorUsed.ImageURL));
            imgImage.ImageUrl = null;
            sponsorUsed.ImageURL = null;
            this.FileUImg.Reset();
        }

        [DirectMethod]
        public void AskNew()
        {
            X.Msg.Confirm("Atención", "¿Desea crear una nuevo sponsor?", new MessageBoxButtonsConfig
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
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la creación de nuevo sponsor" });
        }

        [DirectMethod]
        public void DoNew()
        {
            btnBorrar.Enabled = false;
            oldSponsorUsed.CopySponsor(sponsorUsed);
            sponsorUsed.ClearSponsor();
            LoadSponsorInForm(sponsorUsed);
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Introduzca datos del nuevo sponsor" });
        }

        [DirectMethod]
        public void AskCancel()
        {
            X.Msg.Confirm("Atención", "¿Desea cancelar la edición del sponsor actual?", new MessageBoxButtonsConfig
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
            btnBorrar.Enabled = true;
            sponsorUsed.CopySponsor(oldSponsorUsed);
            LoadSponsorInForm(sponsorUsed);
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la edición" });
        }

        [DirectMethod]
        public void AskDel()
        {
            X.Msg.Confirm("Atención", "¿Desea borrar el sponsor mostrado en la ficha?", new MessageBoxButtonsConfig
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
            if (sponsorUsed.SponsorId == 0)
            { //No Race Type selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay sponsors registrados.").Show();
            }
            else
            {
                using (var db = new ClubSiteContext())
                {
                    Sponsor item = (from sponsors in db.Sponsors
                                    where sponsors.SponsorId == sponsorUsed.SponsorId
                                    select sponsors).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Sponsor con id : {0} no encontrado", sponsorUsed.SponsorId));
                        X.Msg.Alert("Atención", "Sponsor no encontrado").Show();
                        return;
                    }
                    db.Sponsors.Remove(item);
                    db.SaveChanges();
                    this.StoreGPSponsors.DataBind();
                    X.Msg.Alert("Atención", "Sponsor borrado.").Show();

                    //Load data for first race type
                    sponsorUsed = (from sponsors in db.Sponsors
                                   orderby sponsors.Nombre
                                   select sponsors).FirstOrDefault();

                    if (sponsorUsed == null)
                    {
                        //Last item was erased. No items in BD.
                        sponsorUsed = new Sponsor();
                        X.Msg.Alert("Atención", "No queda ningún sponsor registrado en la Base de datos.").Show();
                    }

                    oldSponsorUsed.CopySponsor(sponsorUsed);
                    //Loads model object data into form
                    LoadSponsorInForm(sponsorUsed);
                }
            }
        }

        [DirectMethod]
        public void AskSave()
        {
            bool sigue = true;
            decimal aportInicial = 0;
            decimal aportRecibida = 0;
            string messageError = null;

            //Verify name exists
            if (txbxNombre.Text == "")
            {
                sigue = false;
                messageError = "Falta el nombre del Sponsor.";
            }

            //Verify AportInicial exists and is a number between 0 and 100.000
            if (sigue)
            {
                try
                {
                    aportInicial = Convert.ToDecimal(txbxAportInicial.Text);
                    if (aportInicial < 0 || aportInicial > 100000)
                    {
                        sigue = false;
                        messageError = "La aportación inicial debe estar entre 0 y 100.000";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError = "La aportación inicial revibida debe ser un número.";
                }
            }


            //Verify AportRecibida exists and is a number between 0 and 100.000
            if (sigue)
            {
                try
                {
                    aportRecibida = Convert.ToDecimal(txbxAportRecibida.Text);
                    if (aportRecibida < 0 || aportRecibida > 100000)
                    {
                        sigue = false;
                        messageError = "La aportación recibida debe estar entre 0 y 100.000";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError = "La aportación recibida debe ser un número.";
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
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                using (var db = new ClubSiteContext())
                {
                    Sponsor aSponsor;
                    if (sponsorUsed.SponsorId == 0)
                    { //New Race Type
                        //aSponsor = new Sponsor();
                        aSponsor = LoadSponsorFromForm();
                        db.Sponsors.Add(aSponsor);
                    }
                    else
                    { //Update actual Race Type
                        aSponsor = (from sponsors in db.Sponsors
                                    where sponsors.SponsorId == sponsorUsed.SponsorId
                                    select sponsors).FirstOrDefault();
                        if (aSponsor == null)
                        {
                            // The item wasn't found
                            ModelState.AddModelError("", String.Format("Sponsor con Id : {0} no encontrada", sponsorUsed.SponsorId));
                            X.Msg.Alert("Atención", "Sponsor no encontrado, grabación cancelada").Show();
                            return;
                        }
                        aSponsor.LogoURL = sponsorUsed.LogoURL;
                        aSponsor.ImageURL = sponsorUsed.ImageURL;
                        aSponsor.Nombre = txbxNombre.Text;
                        aSponsor.ContactPerson = txbxContacto.Text;
                        aSponsor.RegDate = Convert.ToDateTime(txbxRegDate.Text);
                        aSponsor.Activo = chbcActivo.Checked;
                        try
                        {
                            aSponsor.AportInicial = Convert.ToDecimal(txbxAportInicial.Text);
                        }
                        catch (Exception)
                        {
                            aSponsor.AportInicial = 0;
                        }
                        try
                        {
                            aSponsor.AportRecibida = Convert.ToDecimal(txbxAportRecibida.Text);
                        }
                        catch (Exception)
                        {
                            aSponsor.AportRecibida = 0;
                        }
                        aSponsor.CondOfertadas = txbxCondOfertadas.Text;
                        aSponsor.WebURL = txbxBlogURL.Text;
                        aSponsor.EMail = txbxEMail.Text;
                        aSponsor.Mobile = txbxMobile.Text;
                        aSponsor.Tlf = txbxTlf.Text;
                        aSponsor.Memo = txbxMemo.Text;
                        aSponsor.Address.Street = txbxStreet.Text;
                        aSponsor.Address.City = txbxCity.Text;
                        aSponsor.Address.Number = txbxNumber.Text;
                        aSponsor.Address.Country = txbxCountry.Text;
                        aSponsor.Address.PostalCode = txbxPostalCode.Text;                        
                        
                        string aux = ReformatNumber(txbxLatitud.Text);
                        if (aux == null)
                            aSponsor.Latitud = 0;
                        else
                        {
                            aSponsor.Latitud = Convert.ToDouble(aux);
                        }

                        aux = ReformatNumber(txbxLongitud.Text);
                        if (aux == null)
                            aSponsor.Longitud = 0;
                        else
                        {
                            aSponsor.Longitud= Convert.ToDouble(aux);
                        }
                    }
                    db.SaveChanges();
                    LoadSponsorInForm(aSponsor);  //To update the ID (identity file)                                  
                    sponsorUsed.CopySponsor(aSponsor);
                    oldSponsorUsed.CopySponsor(sponsorUsed);
                    this.StoreGPSponsors.DataBind();
                    X.Msg.Alert("Atención", "Datos de sponsor grabados.").Show();
                }
                btnBorrar.Enabled = true;
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
        }

        public string ReformatNumber(string aString)
        {
            string result=null;            
            int pointPos = aString.IndexOf('.');
            if (pointPos != -1)                
            {
                System.Text.StringBuilder strBuild = new System.Text.StringBuilder(aString);
                strBuild[pointPos] = ',';
                result = strBuild.ToString();
            }
            return  result;
        }
    }
}