using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using ClubSite.Model;

namespace ClubSite.Account
{
    public partial class Register : Page
    {
        static bool newNumber = false;
        static bool newImage = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //save aditional DataBind of user
            using (var bd = new ClubSiteContext())
            {                
                try
                {
                    string aUserName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName")).Text;
                    string aFirstName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxName")).Text;
                    string aSecondName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxSecondName")).Text;
                    string aBlogURL = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxBlog")).Text;
                    string aMemo = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxMemo")).Text;
                    string aDNI = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxDNI")).Text;
                    DateTime? aBirthDate = null;
                    try
                    {
                        aBirthDate = Convert.ToDateTime(((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxBdate")).Text);
                    }
                    catch
                    {
                        aBirthDate = null;
                    }
                    DateTime aRegDate = DateTime.Now;
                    bool aState = false;
                    bool visible = false;
                    bool federated = ((CheckBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("chbxFederated")).Checked;
                    string aNImageURL = ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgNImageURL")).ImageUrl;
                    string anImageURL = ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgImageURL")).ImageUrl;
                    string aTlf = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxTlf")).Text;
                    string aMobile = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxMobile")).Text;
                    string anEMail = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Email")).Text;
                    string aClubNumber = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxClubNumber")).Text;
                    string aStreet = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxStreet")).Text;
                    string aNumber = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxNumber")).Text;
                    string aCity = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxCity")).Text;
                    string aCountry = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxCountry")).Text;
                    string aPostalCode = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txbxPostalCode")).Text;
                    Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
                    Member aMember = new Member(aUserName, aClubNumber, aFirstName, aSecondName, aDNI, anAddress, aTlf, aMobile, anEMail, 
                        aState, federated, visible, aBirthDate, aMemo, anImageURL, aNImageURL, aBlogURL);                    
                    bd.Members.Add(aMember);
                    bd.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }


            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void btnBorraNImage_Click(object sender, EventArgs e)
        {
            //Response.Write("<script lengue>alert('Mensaje Aqui')</script>");            
            System.IO.File.Delete(Server.MapPath(((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgNImageURL")).ImageUrl));
            ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgNImageURL")).ImageUrl = null;
            //clubberUsed.ImgURL = null;
        }
        protected void btnBorraImage_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgImageURL")).ImageUrl));
            ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgImageURL")).ImageUrl = null;
            //clubberUsed.NImgURL = null;
        }
        protected void btnSubirNImage_Click(object sender, EventArgs e)
        {
            if (((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadNumber")).HasFile)
            {
                string virtualFolder = "../Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = ((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadNumber")).FileName; // Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadNumber")).FileName);
                ((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadNumber")).SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgNImageURL")).ImageUrl = virtualFolder + fileName /*+ extension*/;
                newNumber = true;
            }
        }
        protected void btnSubirImage_Click(object sender, EventArgs e)
        {
            if (((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadImage")).HasFile)
            {
                string virtualFolder = "../Images/Clubbers/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = ((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadImage")).FileName; // Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadImage")).FileName);
                ((FileUpload)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FileUploadImage")).SaveAs(System.IO.Path.Combine(physicalFolder, fileName /*+ extension*/));
                ((Image)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("imgImageURL")).ImageUrl = virtualFolder + fileName /*+ extension*/;
                newImage = true;
            }
        }
    }
}