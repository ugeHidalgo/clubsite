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
    public partial class CarrerasDetalle : System.Web.UI.Page
    {
        public static int aRaceID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                try
                {
                    aRaceID = Convert.ToInt32(Request.QueryString["Id"]);
                    //Search data for SponsorId
                    using (ClubSiteContext db = new ClubSiteContext())
                    {
                        Race aRace = (from r in db.Races where r.Id == aRaceID select r).FirstOrDefault();

                        //Puts data into web forms
                        txbxID.Text = Convert.ToString(aRace.Id);
                        txbxDate.Text = Convert.ToString(aRace.RaceDate);
                        txbxRaceType.Text = aRace.RaceType.Name;
                        txbxPoints.Text = Convert.ToString(aRace.RaceType.Points);
                        imgImage.ImageUrl = aRace.ImageURL;
                        txbxName.Text = aRace.Name;
                        if (aRace.Address != null)
                        {
                            txbxStreet.Text = aRace.Address.Street;
                            txbxNumber.Text = aRace.Address.Number;
                            txbxCity.Text = aRace.Address.City;
                            txbxCountry.Text = aRace.Address.Country;
                            txbxPostalCode.Text = aRace.Address.PostalCode;
                        }
                        txbxMemo.Text = aRace.Memo;

                        //Load data for map
                        ////To avoid problems with the , and . in decimal numbers
                        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                        txbxLatitud.Text = Convert.ToString(aRace.Latitud, culture);
                        txbxLongitud.Text = Convert.ToString(aRace.Longitud, culture);

                        //Loads data for clubbers in race selected ordered by UserName                 
                        var aRace2 = (from r in db.Races
                                      where r.Id == aRaceID
                                      select r).FirstOrDefault();
                        var membersInRace = from m in aRace2.Members
                                            where m.State == true
                                            orderby m.UserName
                                            select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName, m.Number };
                        this.StoreGPClubbersEnComp.DataSource = membersInRace;
                        this.StoreGPClubbersEnComp.DataBind();
                    }
                }
                catch (Exception)
                {
                    txbxName.Text = "";
                }
            }       
        }


        protected void GPRaces_CellClick(object sender, EventArgs e)
        {

        }

        protected void btnOrderUsername_Click(object sender, DirectEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                var aRace2 = (from r in db.Races
                              where r.Id == aRaceID
                              select r).FirstOrDefault();
                StoreGPClubbersEnComp.DataSource = from m in aRace2.Members
                                                   where m.State == true
                                                   orderby m.UserName
                                                   select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName, m.Number };
                StoreGPClubbersEnComp.DataBind();
            }
        }

        protected void btnOrderSecond_Click(object sender, DirectEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                var aRace2 = (from r in db.Races
                              where r.Id == aRaceID
                              select r).FirstOrDefault();
                StoreGPClubbersEnComp.DataSource = from m in aRace2.Members
                                                   where m.State == true
                                                   orderby m.SecondName
                                                   select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName, m.Number };
                StoreGPClubbersEnComp.DataBind();
            }
        }

        protected void btnOrderNumber_Click(object sender, DirectEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                var aRace2 = (from r in db.Races
                              where r.Id == aRaceID
                              select r).FirstOrDefault();
                StoreGPClubbersEnComp.DataSource = from m in aRace2.Members
                                                   where m.State == true
                                                   orderby m.Number
                                                   select new { m.UserName, m.ImageURL, m.NImageURL, m.BlogURL, m.SecondName, m.FirstName, m.Number };
                StoreGPClubbersEnComp.DataBind();
            }
        }
    }
}