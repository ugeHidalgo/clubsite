using ClubSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ClubSite.theClub
{
    public partial class ColabDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int aSponsorId;
            try
            {
                aSponsorId = Convert.ToInt32(Request.QueryString["SponsorId"]);
                //Search data for SponsorId
                using (ClubSiteContext db = new ClubSiteContext())
                {
                    Sponsor aSponsor = (from sp in db.Sponsors where sp.SponsorId == aSponsorId select sp).FirstOrDefault();

                    //Puts data into web forms
                    laSponsorName.Text = aSponsor.Nombre;
                    imgLogo.ImageUrl = aSponsor.LogoURL;                   
                    imgImage.ImageUrl = aSponsor.ImageURL;
                    txbxCondiciones.Text = aSponsor.CondOfertadas;
                    hlWebSite.Text = aSponsor.WebURL;
                    hlWebSite.NavigateUrl = aSponsor.WebURL;
                    laTlf.Text = aSponsor.Tlf;
                    laMail.Text = aSponsor.EMail;
                    if (aSponsor.Address!=null)
                    {
                        laCalle.Text=aSponsor.Address.Street;
                        laNumero.Text=aSponsor.Address.Number;
                        laCiudad.Text=aSponsor.Address.City;
                        laProvincia.Text=aSponsor.Address.Country;
                        laCPostal.Text=aSponsor.Address.PostalCode;
                    }

                    //Load data for map
                    ////To avoid problems with the , and . in decimal numbers
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    txbxLatitud.Text = Convert.ToString(aSponsor.Latitud, culture);
                    txbxLongitud.Text = Convert.ToString(aSponsor.Longitud, culture);

                    //Hide parts if user is not registered
                    try
                    {
                        string user = Membership.GetUser().UserName;
                    }
                    catch (Exception)
                    {
                        laCondiciones.Visible = false;
                        txbxCondiciones.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                laSponsorName.Text = "";
            }                       
        }
    }
}