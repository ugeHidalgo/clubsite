using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;

namespace ClubSite.AdminPages
{
    public partial class Races : System.Web.UI.Page
    {
        public IQueryable<Race> ddlRaces_GetData()
        {
            var db = new ClubSiteContext();
            IQueryable<Race> query = from races in db.Races
                                     orderby races.Name
                                     select races;
            return query;
        }

        public IQueryable ddlRaceTypes_GetData()
        {
            var db = new ClubSiteContext();
            var query = from rt in db.RaceTypes
                                         join s in db.Sports on rt.SportID equals s.SportID
                                         orderby s.Name, rt.Name
                                         select new { rt.RaceTypeID, Name=(s.Name+" / "+rt.Name) };
            return query;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        protected void gvRaces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRaces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRaceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}