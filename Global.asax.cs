using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ClubSite;
using System.Data.Entity;
using ClubSite.Model;

namespace ClubSite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Adding an admoinistrator role ----> Add to web.config : <roleManager enabled="true" /> between <system.web>
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (Membership.GetUser("adminuser") == null)
            {
                Membership.CreateUser("adminuser", "adminuser", "ugehidalgo@gmail.com");
                Roles.AddUserToRole("adminuser", "Administrator");
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
