using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;

namespace ClubSite.AdminPages
{
    public partial class Sponsors : System.Web.UI.Page
    {
        static int sponsorUsedId;
        static Sponsor sponsorUsed;
        static Sponsor oldSponsorUsed;
        static bool newLogo = false;
        static bool newImage = false;

        //public IQueryable<Sponsor> GridView1_GetData()
        //{
        //    var db = new ClubSiteContext();

        //    IQueryable<Sponsor> query = from sponsors in db.Sponsors
        //                                orderby sponsors.Nombre
        //                                select sponsors;
        //    return query;
        //}

        public IQueryable<Sponsor> ddlSponsors_GetData()
        {

            var db = new ClubSiteContext();
            IQueryable<Sponsor> query = from sponsors in db.Sponsors
                                      orderby sponsors.Nombre
                                      select sponsors;
            return query;
        }


        private void LoadSponsorInForm(Sponsor aSponsor)
        {
            sponsorUsedId = aSponsor.SponsorId;
            imgLogoURL.ImageUrl = aSponsor.LogoURL;
            imgLogoURL.AlternateText = "(Sin Logo)";
            imgImageURL.ImageUrl = aSponsor.ImageURL;
            imgImageURL.AlternateText = "(Sin imagen)";
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
                txbxAportInicial.Text="";
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
        }
        private Sponsor LoadSponsorFromForm()
        {
            Sponsor aSponsor = new Sponsor();
            aSponsor.SponsorId = Convert.ToInt16(txbxId.Text);
            aSponsor.LogoURL = imgLogoURL.ImageUrl;
            aSponsor.ImageURL = imgImageURL.ImageUrl;            
            aSponsor.Nombre=txbxNombre.Text;
            aSponsor.ContactPerson=txbxContacto.Text;
            aSponsor.RegDate=Convert.ToDateTime(txbxRegDate.Text);
            aSponsor.Activo=chbcActivo.Checked;
            try
            {
                aSponsor.AportInicial=Convert.ToDecimal(txbxAportInicial.Text);
            }
            catch (Exception)
            {
                aSponsor.AportInicial=0;
            }
            try
            {
                aSponsor.AportRecibida=Convert.ToDecimal(txbxAportRecibida.Text);
            }
            catch (Exception)
            {
                aSponsor.AportRecibida= 0;
            }
            aSponsor.CondOfertadas=txbxCondOfertadas.Text;
            aSponsor.WebURL= txbxBlogURL.Text;
            aSponsor.EMail=txbxEMail.Text;
            aSponsor.Mobile=txbxMobile.Text;
            aSponsor.Tlf=txbxTlf.Text;
            aSponsor.Memo=txbxMemo.Text;            
            aSponsor.Address.Street=txbxStreet.Text;
            aSponsor.Address.City=txbxCity.Text;
            aSponsor.Address.Number=txbxNumber.Text;
            aSponsor.Address.Country=txbxCountry.Text;
            aSponsor.Address.PostalCode=txbxPostalCode.Text;            
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

        protected void ddlSponsors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 actualSpId = Convert.ToInt16(ddlSponsors.SelectedValue);
             
            //Search for the Sponsor and load into model object.
            using (var db = new ClubSiteContext())
            {
                sponsorUsed = (from sponsors in db.Sponsors
                               orderby sponsors.Nombre
                               where sponsors.SponsorId == actualSpId
                               select sponsors).FirstOrDefault();

                if (sponsorUsed == null)
                    Response.Write("<script>alert('No hay ningún Sponsor registrado en la Base de datos.')</script>");
                oldSponsorUsed.CopySponsor(sponsorUsed);

                //Loads model object data into form
                LoadSponsorInForm(sponsorUsed);
            }
            btnBorrar.Enabled = true;
        }

        protected void gvSponsors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Select the id for the race type.            
                Int32 actualSpId = Convert.ToInt32(gvSponsors.SelectedRow.Cells[1].Text);

                //Search for the RaceType and load into model object.
                using (var db = new ClubSiteContext())
                {
                    sponsorUsed = (from sponsors in db.Sponsors
                                   orderby sponsors.Nombre
                                   where sponsors.SponsorId == actualSpId
                                   select sponsors).FirstOrDefault();

                    if (sponsorUsed == null)
                        Response.Write("<script>alert('No hay ningún Sponsor registrado en la Base de datos.')</script>");
                    oldSponsorUsed.CopySponsor(sponsorUsed);

                    //Loads model object data into form
                    LoadSponsorInForm(sponsorUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnBorrar.Enabled = false;
            oldSponsorUsed.CopySponsor(sponsorUsed);
            sponsorUsed.ClearSponsor();
            LoadSponsorInForm(sponsorUsed);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {           
            bool sigue = true;
            decimal aportInicial = 0;
            decimal aportRecibida = 0;
            string messageError = null;

            //Verify name exists
            if (txbxNombre.Text == "")
            {
                sigue = false;
                messageError = "<script>alert('Falta el nombre del Sponsor')</script>";
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
                        messageError = "<script>alert('La aportación inicial debe estar entre 0 y 100.000')</script>";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError = "<script>alert('la aportación inicial revibida debe ser un número.')</script>";
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
                        messageError = "<script>alert('La aportación recibida debe estar entre 0 y 100.000')</script>";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError = "<script>alert('La aportación recibida debe ser un número.')</script>";
                }
            }

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
                            return;
                        }
                        aSponsor.LogoURL = imgLogoURL.ImageUrl;
                        aSponsor.ImageURL = imgImageURL.ImageUrl;
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
                    }
                    db.SaveChanges();
                    LoadSponsorInForm(aSponsor);  //To update the ID (identity file)                                  
                    sponsorUsed.CopySponsor(aSponsor);
                    oldSponsorUsed.CopySponsor(sponsorUsed);
                    gvSponsors.DataBind();
                    Response.Write("<script>alert('Datos de Sponsor grabados')</script>");
                }
                btnBorrar.Enabled = true;
            }
            else
            {
                Response.Write(messageError);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBorrar.Enabled = true;
            sponsorUsed.CopySponsor(oldSponsorUsed);
            LoadSponsorInForm(sponsorUsed);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (sponsorUsed.SponsorId == 0)
            { //No Race Type selected
                Response.Write(@"<script>alert('No hay nada que borrar ya que no hay Sponsors registrados en la base de datos.')</script>");
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
                        return;
                    }
                    db.Sponsors.Remove(item);
                    db.SaveChanges();
                    gvSponsors.DataBind();
                   

                    try
                    {
                        //Select the id for the sponsor           
                        Int32 actualSpId = Convert.ToInt32(gvSponsors.SelectedRow.Cells[1].Text);

                        //Search for the RaceType and load into model object.
                        sponsorUsed = (from sponsors in db.Sponsors
                                       orderby sponsors.Nombre
                                       where sponsors.SponsorId == actualSpId
                                       select sponsors).FirstOrDefault();

                        if (sponsorUsed == null)
                        {
                            sponsorUsed = new Sponsor();
                            Response.Write("<script>alert('No queda ningún Sponsor registrado en la Base de datos.')</script>");
                        }
                    }
                    catch (Exception)
                    {
                        //Last object was deleted, search for new object if it exists
                        try
                        {
                            //Select the id for the race type.            
                            gvSponsors.SelectedIndex = gvSponsors.Rows.Count - 1;
                            Int32 actualSpId = Convert.ToInt32(gvSponsors.SelectedRow.Cells[1].Text);

                            //Search for Sponsor and load into model object.
                            sponsorUsed = (from sponsors in db.Sponsors
                                           orderby sponsors.Nombre
                                           where sponsors.SponsorId == actualSpId
                                           select sponsors).FirstOrDefault();

                            if (sponsorUsed == null)
                            {
                                sponsorUsed = new Sponsor();
                                Response.Write("<script>alert('No queda ningún Sponsor registrado en la Base de datos.')</script>");
                            }
                        }
                        catch (Exception)
                        {
                            sponsorUsed = new Sponsor();
                            Response.Write("<script>alert('No queda ningún Sponsor registrado en la Base de datos.')</script>");
                        }
                    }
                    oldSponsorUsed.CopySponsor(sponsorUsed);
                    //Loads model object data into form
                    LoadSponsorInForm(sponsorUsed);
                }
            }
        }

        protected void btnBorraImage_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(imgImageURL.ImageUrl));
            imgImageURL.ImageUrl = null;
            sponsorUsed.ImageURL = null;
        }

        protected void btnSubirImage_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFile)
            {
                string virtualFolder = "../Images/Sponsors/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUploadImage.FileName; //Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUploadImage.FileName);
                FileUploadImage.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgImageURL.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newImage = true;
                sponsorUsed.ImageURL = imgImageURL.ImageUrl;
            }
        }

        protected void btnBorraLogo_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(imgLogoURL.ImageUrl));
            imgLogoURL.ImageUrl = null;
            sponsorUsed.LogoURL = null;
        }

        protected void btnSubeLogo_Click(object sender, EventArgs e)
        {
            if (FileUploadLogo.HasFile)
            {
                string virtualFolder = "../Images/Sponsors/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = FileUploadLogo.FileName; // Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUploadLogo.FileName);
                FileUploadLogo.SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                imgLogoURL.ImageUrl = virtualFolder + fileName /*+ extension*/;
                newLogo = true;
                sponsorUsed.LogoURL = imgLogoURL.ImageUrl;
            }
        }



        
    }
}