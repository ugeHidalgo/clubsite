using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;

namespace ClubSite.AdminPages
{
    public partial class RaceTypes : System.Web.UI.Page
    {
        static RaceType rtUsed;
        static RaceType oldRtUsed;

        //public IQueryable<RaceType> GridView1_GetData()
        //{
        //    var db = new ClubSiteContext();
        //    IQueryable<RaceType> query = from raceTypes in db.RaceTypes
        //                                 orderby raceTypes.Name
        //                                 select raceTypes;         
        //    return query;
        //}
        public IQueryable<Sport> ddlDeportes_GetData()
        {

            var db = new ClubSiteContext();
            IQueryable<Sport> query = from sports in db.Sports
                                      orderby sports.Name
                                      select sports;                            
            return query;
        }

        public void LoadRaceTypeInForm(RaceType aRaceType)
        {
            txbxId.Text = Convert.ToString(aRaceType.RaceTypeID);
            txbxSportID.Text = Convert.ToString(aRaceType.SportID);
            ListItem aValue = ddlDeportes.Items.FindByValue(txbxSportID.Text);
            ddlDeportes.SelectedIndex = ddlDeportes.Items.IndexOf(aValue);
            txbxName.Text = aRaceType.Name;
            try
            {
                txbxPuntos.Text = Convert.ToString(aRaceType.Points);
            }
            catch (Exception)
            {
                txbxPuntos.Text = "0";
            }
            txbxMemo.Text = aRaceType.Memo;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rtUsed = new RaceType();
                oldRtUsed = new RaceType();
                using (var db = new ClubSiteContext())
                {
                    rtUsed = (from raceTypes in db.RaceTypes
                              orderby raceTypes.Name
                              select raceTypes).FirstOrDefault();

                    if (rtUsed == null)
                    {
                        rtUsed = new RaceType();
                        Response.Write("<script>alert('No hay ningún tipo de carrera registrada en la Base de datos.')</script>");
                    }
                    oldRtUsed.CopyRaceType(rtUsed);
                    LoadRaceTypeInForm(rtUsed);
                }
            }
        }
        protected void gvRaceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Select the id for the race type.            
                Int32 actualRtId = Convert.ToInt32(gvRaceTypes.SelectedRow.Cells[1].Text);

                //Search for the RaceType and load into model object.
                using (var db = new ClubSiteContext())
                {
                    rtUsed = (from raceTypes in db.RaceTypes
                              orderby raceTypes.Name
                              where raceTypes.RaceTypeID == actualRtId
                              select raceTypes).FirstOrDefault();

                    if (rtUsed == null)                    
                        Response.Write("<script>alert('No hay ningún tipo de carrera registrada en la Base de datos.')</script>");                    
                    oldRtUsed.CopyRaceType(rtUsed);

                    //Loads model object data into form
                    LoadRaceTypeInForm(rtUsed);
                }
            }
            catch (Exception){}
            btnBorrar.Enabled = true;
        }
        protected void ddlDeportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbxSportID.Text = Convert.ToString(ddlDeportes.SelectedValue);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            oldRtUsed.CopyRaceType(rtUsed);
            rtUsed.ClearRaceType();
            LoadRaceTypeInForm(rtUsed);
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            bool sigue = true;
            int points = 0;
            int aSportIDSelected = 0;
            string messageError = null;

            //Verify name exists
            if (txbxName.Text == "")
            {
                sigue = false;
                messageError = "<script>alert('Falta el nombre del tipo de carrera')</script>";
            }

            //Verify points exists and are between 0 and 10.000
            if (sigue )
            {
                try
                {
                    points = Convert.ToInt32(txbxPuntos.Text);
                    if (points < 0 || points > 10000)
                    {
                        sigue = false;
                        messageError = "<script>alert('Los puntos asignados deben ser un número entre 0 y 10.000')</script>";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError="<script>alert('Debes asignar un valor numérico entre 0 y 10.000 para los puntos.')</script>";
                }
            }

            //Verify is a SportID was choosed.
            if (sigue)
            {
                try
                {
                    aSportIDSelected = Convert.ToInt32(txbxSportID.Text);
                    if (aSportIDSelected <= 0)
                    {
                        sigue = false;
                        messageError = "<script>alert('Escoje el tipo de deporte al que pertenece la carrera.')</script>";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError="<script>alert('Escoje el tipo de deporte al que pertenece la carrera.')</script>";
                }
            }

            //Save if conditions are ok.
            if (sigue)
            {
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                using (var db = new ClubSiteContext())
                {
                    RaceType aRacetype;
                    if (rtUsed.RaceTypeID == 0)
                    { //New Race Type
                        aRacetype = new RaceType();
                        aRacetype.Name = txbxName.Text;
                        aRacetype.Points = points;
                        aRacetype.SportID = aSportIDSelected;
                        aRacetype.Memo = txbxMemo.Text;
                        db.RaceTypes.Add(aRacetype);
                    }
                    else
                    { //Update actual Race Type
                        aRacetype = (from racetypes in db.RaceTypes
                                     where racetypes.RaceTypeID == rtUsed.RaceTypeID
                                     select racetypes).FirstOrDefault();
                        if (aRacetype == null)
                        {
                            // The item wasn't found
                            ModelState.AddModelError("", String.Format("Tipo de carrera con Id : {0} no encontrada", rtUsed.RaceTypeID));
                            return;
                        }
                        aRacetype.Name = txbxName.Text;
                        aRacetype.Points = points;
                        aRacetype.SportID = aSportIDSelected;
                        aRacetype.Memo = txbxMemo.Text;
                    }
                    db.SaveChanges();
                    LoadRaceTypeInForm(aRacetype);  //To update the ID (identity file)                                  
                    rtUsed.CopyRaceType(aRacetype);
                    oldRtUsed.CopyRaceType(rtUsed);
                    gvRaceTypes.DataBind();
                    Response.Write("<script>alert('Nuevo tipo de carrera grabada')</script>");
                }
                btnBorrar.Enabled = true;
            }
            else
            {
                Response.Write(messageError);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            rtUsed.CopyRaceType(oldRtUsed);
            LoadRaceTypeInForm(rtUsed);
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (rtUsed.RaceTypeID == 0)
            { //No Race Type selected
                Response.Write(@"<script>alert('No hay nada que borrar ya que no hay tipos de carrera registradas.')</script>");
            }
            else
            {
                using (var db = new ClubSiteContext())
                {
                    RaceType item = (from racetypes in db.RaceTypes
                                     where racetypes.RaceTypeID == rtUsed.RaceTypeID
                                     select racetypes).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Tipo de carrera con id : {0} no encontrado", rtUsed.RaceTypeID));
                        return;
                    }
                    db.RaceTypes.Remove(item);
                    db.SaveChanges();
                    gvRaceTypes.DataBind();

                    try
                    {
                        //Select the id for the race type.            
                        Int32 actualRtId = Convert.ToInt32(gvRaceTypes.SelectedRow.Cells[1].Text);

                        //Search for the RaceType and load into model object.
                        rtUsed = (from raceTypes in db.RaceTypes
                                  orderby raceTypes.Name
                                  where raceTypes.RaceTypeID == actualRtId
                                  select raceTypes).FirstOrDefault();

                        if (rtUsed == null)
                        {
                            rtUsed = new RaceType();
                            Response.Write("<script>alert('No queda ningún tipo de carrera registrada en la Base de datos.')</script>");
                        }
                    }
                    catch (Exception) 
                    {
                        //Last object was deleted, search for new object if it exists
                        try
                        {
                            //Select the id for the race type.            
                            gvRaceTypes.SelectedIndex = gvRaceTypes.Rows.Count - 1;
                            Int32 actualRtId = Convert.ToInt32(gvRaceTypes.SelectedRow.Cells[1].Text);

                            //Search for the RaceType and load into model object.
                            rtUsed = (from raceTypes in db.RaceTypes
                                      orderby raceTypes.Name
                                      where raceTypes.RaceTypeID == actualRtId
                                      select raceTypes).FirstOrDefault();

                            if (rtUsed == null)
                            {
                                rtUsed = new RaceType();
                                Response.Write("<script>alert('No queda ningún tipo de carrera registrada en la Base de datos.')</script>");
                            }
                        }
                        catch (Exception)
                        {
                            rtUsed = new RaceType();
                            Response.Write("<script>alert('No queda ningún tipo de carrera registrada en la Base de datos.')</script>");
                        }
                    }
                    oldRtUsed.CopyRaceType(rtUsed);
                    //Loads model object data into form
                    LoadRaceTypeInForm(rtUsed);
                }
            }
        }
    }
}