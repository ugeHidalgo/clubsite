using ClubSite.Model;
using Subgurim.Controles;
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
                    imgLogoURL.ImageUrl = aSponsor.LogoURL;                   
                    imgImageURL.ImageUrl = aSponsor.ImageURL;
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
                    double latitud = aSponsor.Latitud;
                    double longitud = aSponsor.Longitud;
                    GLatLng ubicacion = new GLatLng(latitud, longitud);
                    GMap1.setCenter(ubicacion, 15);

                    //Establecemos alto y ancho en px
                    GMap1.Height = 500;
                    GMap1.Width = 500;

                    //Adiciona el control de la parte izq superior (moverse, ampliar y reducir)
                    GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

                    //GControl.preBuilt.MapTypeControl: permite elegir un tipo de mapa y otro.
                    GMap1.Add(new GControl(GControl.preBuilt.MapTypeControl));

                    //Con esto podemos definir el icono que se mostrara en la ubicacion
                    //#region Crear Icono
                    //GIcon iconPropio = new GIcon();
                    //iconPropio.image = "../images/iconBuilding.png";
                    //iconPropio.shadow = "../images/iconBuildingS.png";
                    //iconPropio.iconSize = new GSize(32, 32);
                    //iconPropio.shadowSize = new GSize(29, 16);
                    //iconPropio.iconAnchor = new GPoint(10, 18);
                    //iconPropio.infoWindowAnchor = new GPoint(10, 9);
                    //#endregion

                    //Pone la marca de gota de agua con el nombre de la ubicacion
                    GMarker marker = new GMarker(ubicacion);
                    string strMarker = "<div style='width: 250px; height: 185px'><b>" +
                        "<span style='color:#ff7e00'></span>" + laSponsorName.Text + "</b><br>" +
                        " C/ " + laCalle.Text + ", No " + laNumero.Text + " <br /> "+ laCPostal.Text + " " +
                          laCiudad.Text + ", " + laProvincia.Text + "<br />" +
                        "Tel: "+ laTlf.Text +"<br />" +
                        "Web: <a href='" + hlWebSite.Text + "'>" + hlWebSite.Text + "</a>" +
                        "<br />Email: <a href='mailto:" + laMail.Text + ">" + laMail.Text + "</a><br><br></div>";
                    GInfoWindow window = new GInfoWindow(marker, strMarker, true);
                    GMap1.Add(window);

                    GMap1.enableHookMouseWheelToZoom = true;

                    //Tipo de mapa a mostrar
                    GMap1.mapType = GMapType.GTypes.Normal;

                    //Moverse con el cursor del teclado
                    GMap1.enableGKeyboardHandler = true;

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