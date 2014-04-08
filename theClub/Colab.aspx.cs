using ClubSite.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubSite.theClub
{
    public partial class Colab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                using (var db = new ClubSiteContext())
                {
                    var data = from s in db.Sponsors
                               orderby s.Nombre
                               where (s.Activo == true) 
                               select new { s.Nombre, s.LogoURL, s.SponsorId };

                    this.Store1.DataSource = data;
                    this.Store1.DataBind();
                }
            }
        }
    }
}