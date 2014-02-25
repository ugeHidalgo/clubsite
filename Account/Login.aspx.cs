using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;

namespace ClubSite.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void Unnamed1_LoggedIn(object sender, EventArgs e)
        {
            //Search user in BD and obtain his active value
            string user = LoginControl.UserName;
            bool canPass = false;

            //Search for user in users BD to check his state.

            //Search for user in users BD to check his state.
            using (var db = new ClubSiteContext())
            {
                var userData = (from users in db.Members
                                where users.UserName == user
                                select users).FirstOrDefault();
                if (userData != null)
                    canPass = userData.State;
            }

            if (!canPass)
            {                            
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                Response.Redirect("/Account/LoginNotActive.aspx");
            }
        }
    }
}