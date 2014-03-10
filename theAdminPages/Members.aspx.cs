using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Security;

namespace ClubSite.AdminPages
{
    public partial class Members : System.Web.UI.Page
    {
        static string actualUserName;
        static Member memberUsed;
        static Member oldMemberUsed;
        static bool newNumber = false;
        static bool newImage = false;

        public IQueryable<Member> GridView1_GetData()
        {
            var db = new ClubSiteContext();

            IQueryable<Member> query = from members in db.Members
                                       orderby members.UserName
                                       select members;
            return query;
        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ClubSite.Model.Race> gvRaces_GetData()
        {
            var db = new ClubSiteContext();

            IQueryable<ClubSite.Model.Race> query = from races in db.Races
                                       orderby races.Name
                                       select races;
            return query;
        }
        public IQueryable<Member> ddlMembers_GetData()
        {

            var db = new ClubSiteContext();
            IQueryable<Member> query = from members in db.Members
                                        orderby members.UserName
                                        select members;
            return query;
        }
        public IQueryable dllRaces_GetData()
        {
            ClubSiteContext db = new ClubSiteContext();
            IQueryable query = from r in db.Races
                               orderby r.Name
                               select new { aRace = (r.Name), r.Id };
            return query;

        }
        
        private void LoadMemberInForm(Member aMember)
        {
            actualUserName = aMember.UserName;
            txbxUserName.Text = aMember.UserName;
            txbxFirstName.Text = aMember.FirstName;
            txbxSecondName.Text = aMember.SecondName;
            txbxBlogURL.Text = aMember.BlogURL;
            txbxMemo.Text = aMember.Memo;
            txbxDNI.Text = aMember.DNI;
            txbxBdate.Text = aMember.BirthDate.ToString();
            chbxFederated.Checked = aMember.Federated;
            chBxActiveUser.Checked = aMember.State;
            chbxVisible.Checked = aMember.Visible;
            imgNImageURL.ImageUrl = aMember.NImageURL;
            imgNImageURL.AlternateText = "(Sin imagen)";
            imgImageURL.ImageUrl = aMember.ImageURL;
            imgImageURL.AlternateText = "(Sin imagen)";
            txbxTlf.Text = aMember.Tlf;
            txbxMobile.Text = aMember.Mobile;
            txbxEMail.Text = aMember.EMail;
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                memberUsed = new Member();
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
                        Response.Write("<script>alert('No hay ningún usuario registrado en la Base de datos. Vaya al formulario de registro para crear nuevos usuarios.')</script>");
                    }
                    else
                    {
                        LoadMemberInForm(aMember);
                        memberUsed = aMember;
                    }
                    oldMemberUsed = memberUsed;
                }
            }
        }
       
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualUserName = GridView1.SelectedRow.Cells[3].Text;
            using (var db = new ClubSiteContext())
            {
                var aMember = (from members in db.Members
                               where members.UserName == actualUserName
                               select members).First();
                if (aMember == null)
                {
                    actualUserName = "";
                    memberUsed = new Member();
                    LoadMemberInForm(memberUsed);
                    Response.Write("<script>alert('Actualmente no hay ningún usuario registrado')</script>");
                }
                else
                {
                    LoadMemberInForm(aMember);
                    memberUsed = aMember;
                }
                oldMemberUsed = memberUsed;
            }
        }
        protected void ddlMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string actualUserName = ddlMembers.SelectedValue;
            using (var db = new ClubSiteContext())
            {
                var aMember = (from members in db.Members
                               where members.UserName == actualUserName
                               select members).First();
                if (aMember == null)
                {
                    actualUserName = "";
                    memberUsed = new Member();
                    LoadMemberInForm(memberUsed);
                    Response.Write("<script>alert('Actualmente no hay ningún usuario registrado')</script>");
                }
                else
                {
                    LoadMemberInForm(aMember);
                    memberUsed = aMember;
                }
                oldMemberUsed = memberUsed;
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Member aMember;
                if ((actualUserName == "") || (actualUserName == null))
                { //No member selected
                    aMember = new Member();
                    Response.Write(@"<script>alert('Al estar la base de usuarios vacía no hay ningún usuario seleccionado. Para crear usuarios nuevos vaya al formulario de registro.')</script>");
                }
                else
                { //Update actual member
                    aMember = (from members in db.Members
                               where members.UserName == actualUserName
                               select members).Single();

                    try
                    {
                        aMember.FirstName = txbxFirstName.Text;
                        aMember.SecondName = txbxSecondName.Text;
                        aMember.BlogURL = txbxBlogURL.Text;
                        aMember.Memo = txbxMemo.Text;
                        aMember.DNI = txbxDNI.Text;
                        try
                        {
                            aMember.BirthDate = Convert.ToDateTime(txbxBdate.Text);
                        }
                        catch
                        {
                            aMember.BirthDate = null;
                        }
                        aMember.Federated = chbxFederated.Checked;
                        aMember.State = chBxActiveUser.Checked;
                        aMember.Visible = chbxVisible.Checked;
                        aMember.NImageURL = imgNImageURL.ImageUrl;
                        aMember.ImageURL = imgImageURL.ImageUrl;
                        aMember.Tlf = txbxTlf.Text;
                        aMember.Mobile = txbxMobile.Text;
                        aMember.EMail = txbxEMail.Text;
                        aMember.Address.Street = txbxStreet.Text;
                        aMember.Address.Number = txbxNumber.Text;
                        aMember.Address.City = txbxCity.Text;
                        aMember.Address.Country = txbxCountry.Text;
                        aMember.Address.PostalCode = txbxPostalCode.Text;
                        db.SaveChanges();
                        memberUsed = aMember;
                        oldMemberUsed = aMember;
                        Response.Write("<script>alert('Datos de ususario grabados')</script>");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    GridView1.DataBind();
                    newNumber = false;
                    newImage = false;
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (newNumber)
            {
                if (System.IO.File.Exists(Server.MapPath(imgNImageURL.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgNImageURL.ImageUrl));

            }
            if (newImage)
            {
                if (System.IO.File.Exists(Server.MapPath(imgImageURL.ImageUrl)))
                    System.IO.File.Delete(Server.MapPath(imgImageURL.ImageUrl));
            }
            LoadMemberInForm(oldMemberUsed);
            memberUsed = oldMemberUsed;
            GridView1.DataBind();
            newNumber = false;
            newImage = false;
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if ((actualUserName == "") || (actualUserName == null))
            { //No member selected
                Response.Write(@"<script>alert('No hay nada que borrar ya que no hay usuarios registrados.')</script>");
            }
            else
            {
                Response.Write(@"<script>if(!confirm('¿Borramos el usuario seleccionado?'))return false</script>");
                
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
                    if (System.IO.File.Exists(Server.MapPath(imgNImageURL.ImageUrl)))
                        System.IO.File.Delete(Server.MapPath(imgNImageURL.ImageUrl));
                    if (System.IO.File.Exists(Server.MapPath(imgImageURL.ImageUrl)))
                        System.IO.File.Delete(Server.MapPath(imgImageURL.ImageUrl));
                    Response.Write("<script>alert('Usuario Borrado')</script>");
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
                        Response.Write("<script>alert('Ya no hay ningún usuario registrado. Para crear nuevos usuarios vaya al formulario de registro')</script>");
                    }
                    else
                    {
                        LoadMemberInForm(aMember);
                        memberUsed = aMember;
                    }
                    oldMemberUsed = memberUsed;
                }
                //4-Refresh the GridView
                GridView1.DataBind();
            }
        }

        protected void btnBorraNImage_Click(object sender, EventArgs e)
        {
            //Response.Write("<script lengue>alert('Mensaje Aqui')</script>");            
            System.IO.File.Delete(Server.MapPath(imgNImageURL.ImageUrl));
            imgNImageURL.ImageUrl = null;
            memberUsed.NImageURL = null;
        }
        protected void btnBorraImage_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(imgImageURL.ImageUrl));
            imgImageURL.ImageUrl = null;
            memberUsed.ImageURL = null;
        }
        protected void btnSubirNImage_Click(object sender, EventArgs e)
        {
            if (FileUploadNumber.HasFile)
            {
                string virtualFolder = "~/Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUploadNumber.FileName);
                FileUploadNumber.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));
                imgNImageURL.ImageUrl = virtualFolder + fileName + extension;
                newNumber = true;
                memberUsed.NImageURL = imgNImageURL.ImageUrl;
            }
        }
        protected void btnSubirImage_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFile)
            {
                string virtualFolder = "~/Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUploadImage.FileName);
                FileUploadImage.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));
                imgImageURL.ImageUrl = virtualFolder + fileName + extension;
                newImage = true;
                memberUsed.ImageURL = imgImageURL.ImageUrl;
            }
        }

        protected void btnAddRace_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelrace_Click(object sender, EventArgs e)
        {

        }




    }
}