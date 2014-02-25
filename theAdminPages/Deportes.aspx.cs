using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;

namespace ClubSite.theAdminPages
{
    public partial class Deportes : System.Web.UI.Page
    {
        static Sport sportUsed;
        static Sport oldSportUsed;

        public IQueryable<Sport> GridView1_GetData()
        {
            var db = new ClubSiteContext();
            IQueryable<Sport> query = from sports in db.Sports
                                      orderby sports.Name
                                      select sports;
            return query;
        }
        public void LoadSportInForm(Sport aSport)
        {
            txbxId.Text = Convert.ToString(aSport.SportID);
            txbxName.Text = aSport.Name;
            txbxMemo.Text = aSport.Memo;
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                sportUsed = new Sport();
                oldSportUsed = new Sport();
                using (var db = new ClubSiteContext())
                {
                    sportUsed = (from sports in db.Sports
                                 orderby sports.Name
                                 select sports).FirstOrDefault();

                    if (sportUsed == null)
                    {
                        sportUsed = new Sport();
                        Response.Write("<script>alert('No hay ningún deporte registrado en la Base de datos.')</script>");
                    }
                    oldSportUsed.CopySport(sportUsed);
                    LoadSportInForm(sportUsed);
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 actualSportId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                using (var db = new ClubSiteContext())
                {
                    sportUsed = (from sports in db.Sports
                                 orderby sports.Name
                                 where sports.SportID == actualSportId
                                 select sports).FirstOrDefault();

                    if (sportUsed == null)
                    {                        
                        Response.Write("<script>alert('No hay ningún deporte registrado en la Base de datos.')</script>");
                    }
                    oldSportUsed.CopySport(sportUsed);
                    LoadSportInForm(sportUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;            
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (sportUsed.SportID == 0)
            { //No sport selected
                Response.Write(@"<script>alert('No hay nada que borrar ya que no hay deportes registrados.')</script>");
            }
            else
            {                
                using (var db = new ClubSiteContext())
                {
                    Sport item = (from sports in db.Sports
                                  where sports.SportID == sportUsed.SportID
                                  select sports).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Deporte con id : {0} no encontrado", sportUsed.SportID));
                        return;
                    }
                    db.Sports.Remove(item);
                    db.SaveChanges();
                    GridView1.DataBind();
                    try
                    {
                        Int32 actualSportId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

                        sportUsed = (from sports in db.Sports
                                     orderby sports.Name
                                     where sports.SportID == actualSportId
                                     select sports).FirstOrDefault();

                        if (sportUsed == null)
                        {
                            sportUsed = new Sport();
                            Response.Write("<script>alert('No queda ningún deporte registrado en la Base de datos.')</script>");

                        }

                    }
                    catch (Exception)
                    {                       
                        //Last object was deleted, search for new object if it exists                        
                        try
                        {
                            GridView1.SelectedIndex = GridView1.Rows.Count - 1;
                            Int32 actualSportId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

                            sportUsed = (from sports in db.Sports
                                         orderby sports.Name
                                         where sports.SportID == actualSportId
                                         select sports).FirstOrDefault();
                            if (sportUsed == null) //data base empty
                            {
                                sportUsed = new Sport();
                                Response.Write("<script>alert('No queda ningún deporte registrado en la Base de datos.')</script>");
                            }
                        }
                        catch (Exception)
                        {
                            sportUsed = new Sport();
                            Response.Write("<script>alert('No queda ningún deporte registrado en la Base de datos.')</script>");
                        }
                    }
                    oldSportUsed.CopySport(sportUsed);
                    LoadSportInForm(sportUsed);
                    
                }
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            //Verify conditions
            if (txbxName.Text == "")
            {
                Response.Write("<script>alert('Falta el nombre del deporte')</script>");
            }
            else
            {
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                using (var db = new ClubSiteContext())
                {
                    Sport aSport;
                    if (sportUsed.SportID == 0)
                    { //New Sport
                        aSport = new Sport();
                        aSport.Name = txbxName.Text;
                        aSport.Memo = txbxMemo.Text;
                        db.Sports.Add(aSport);
                    }
                    else
                    { //Update actual Sport
                        aSport = (from sports in db.Sports
                                  where sports.SportID == sportUsed.SportID
                                  select sports).FirstOrDefault();
                        if (aSport == null)
                        {
                            // The item wasn't found
                            ModelState.AddModelError("", String.Format("Deporte con Id : {0} no encontrado", sportUsed.SportID));
                            return;
                        }
                        aSport.SportID = Convert.ToInt32(txbxId.Text);
                        aSport.Name = txbxName.Text;
                        aSport.Memo = txbxMemo.Text;
                    }
                    db.SaveChanges();
                    LoadSportInForm(aSport);  //To update the ID (identity file)                                  
                    sportUsed = aSport;
                    oldSportUsed.CopySport(sportUsed);
                    GridView1.DataBind();
                    Response.Write("<script>alert('Datos de deporte grabados')</script>");
                }
                btnBorrar.Enabled = true;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            sportUsed.CopySport(oldSportUsed);
            LoadSportInForm(sportUsed);
            GridView1.DataBind();
            btnBorrar.Enabled = true;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            oldSportUsed.CopySport(sportUsed);
            sportUsed.ClearSport();
            LoadSportInForm(sportUsed);
        }
    }
}