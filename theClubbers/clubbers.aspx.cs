using ClubSite.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubSite.theClubbers
{
    public partial class clubbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                using (var db = new ClubSiteContext())
                {
                    var data = from m in db.Members
                               orderby m.UserName
                               where (m.State == true) && (m.Visible == true)
                               select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName };

                    this.Store1.DataSource = data;
                    this.Store1.DataBind();
                }
            }
        }

        protected void btnOrderUsername_Click(object sender, DirectEventArgs e)
        {
            using (var db = new ClubSiteContext())
                {
                    var data = from m in db.Members
                               orderby m.UserName
                               where (m.State == true) && (m.Visible == true)
                               select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName };

                    this.Store1.DataSource = data;
                    this.Store1.DataBind();
            }
        }

        protected void btnOrderSecond_Click(object sender, DirectEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                var data = from m in db.Members
                           orderby m.SecondName
                           where (m.State == true) && (m.Visible == true)
                           select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName };

                this.Store1.DataSource = data;
                this.Store1.DataBind();
            }
        }

    }
}