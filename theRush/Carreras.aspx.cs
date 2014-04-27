using ClubSite.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubSite.theRush
{
    public partial class Carreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!X.IsAjaxRequest)
            {
                DateTime fromDate= new DateTime(DateTime.Now.Year,1,1);
                DateTime toDate = new DateTime(DateTime.Now.Year, 12, 31);
                dtfFromDate.SelectedDate = fromDate;
                dtfToDate.SelectedDate = toDate;
                using (var db = new ClubSiteContext())
                {
                    var data = from r in db.Races
                               orderby r.Name, r.RaceDate 
                               where (r.RaceDate>=fromDate) && (r.RaceDate<=toDate)
                               select new { r.Id, r.Name, r.RaceDate, r.ImageURL  };
                    this.Store1.DataSource = data;
                    this.Store1.DataBind();
                }
            }
        }

        protected void btnOrderDate_Click(object sender, DirectEventArgs e)
        {
            DateTime fromDate = dtfFromDate.SelectedDate;
            DateTime toDate = dtfToDate.SelectedDate;
            using (var db = new ClubSiteContext())
            {
                var data = from r in db.Races
                           orderby r.RaceDate, r.Name
                           where (r.RaceDate >= fromDate) && (r.RaceDate <= toDate)
                           select new { r.Id, r.Name, r.RaceDate, r.ImageURL };
                this.Store1.DataSource = data;
                this.Store1.DataBind();
            }
        }

        protected void btnOrderName_Click(object sender, DirectEventArgs e)
        {
            DateTime fromDate = dtfFromDate.SelectedDate;
            DateTime toDate = dtfToDate.SelectedDate;
            using (var db = new ClubSiteContext())
            {
                var data = from r in db.Races
                           orderby r.Name, r.RaceDate
                           where (r.RaceDate >= fromDate) && (r.RaceDate <= toDate)
                           select new { r.Id, r.Name, r.RaceDate, r.ImageURL };
                this.Store1.DataSource = data;
                this.Store1.DataBind();
            }
        }        
    }
}