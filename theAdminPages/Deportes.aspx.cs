using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;
using Ext.Net;

namespace ClubSite.theAdminPages
{
    public partial class Deportes : System.Web.UI.Page
    {
        static Sport sportUsed;
        static Sport oldSportUsed;

        public void LoadSportInForm(Sport aSport)
        {
            txfId.Text = Convert.ToString(aSport.SportID);
            txfName.Text = aSport.Name;
            txfMemo.Text = aSport.Memo;
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
        protected void GridPanel1_Cell_Click(object sender, EventArgs e)
        {
            try
            {
                CellSelectionModel sm = this.GridPanel1.GetSelectionModel() as CellSelectionModel;             
                Int32 actualSportId = Convert.ToInt32(sm.SelectedCell.RecordID);
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

        protected void btnBorrar_Click(object sender, DirectEventArgs e)
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
                    GridPanel1.DataBind();
                    try
                    {
                        CellSelectionModel sm = this.GridPanel1.GetSelectionModel() as CellSelectionModel;
                        sm.SelectedCell.RowIndex = sm.SelectedCell.RowIndex - 1;
                        Int32 actualSportId = Convert.ToInt32(sm.SelectedCell.RecordID);
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
                            CellSelectionModel sm = this.GridPanel1.GetSelectionModel() as CellSelectionModel;             
                            Int32 actualSportId = Convert.ToInt32(sm.SelectedCell.RecordID);                            
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
        protected void btnGrabar_Click(object sender, DirectEventArgs e)
        {
            //Verify conditions
            if (txfName.Text == "")
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
                        aSport.Name = txfName.Text;
                        aSport.Memo = txfMemo.Text;
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
                        aSport.SportID = Convert.ToInt32(txfId.Text);
                        aSport.Name = txfName.Text;
                        aSport.Memo = txfMemo.Text;
                    }
                    db.SaveChanges();
                    LoadSportInForm(aSport);  //To update the ID (identity file)                                  
                    sportUsed = aSport;
                    oldSportUsed.CopySport(sportUsed);
                    GridPanel1.DataBind();
                    Response.Write("<script>alert('Datos de deporte grabados')</script>");
                }
                btnBorrar.Enabled = true;
            }
        }
        protected void btnCancelar_Click(object sender, DirectEventArgs e)
        {
            sportUsed.CopySport(oldSportUsed);
            LoadSportInForm(sportUsed);
            GridPanel1.DataBind();
            btnBorrar.Enabled = true;
        }
        // [DirectMethod]
        //public void btnNuevo_Click(string result)  //(object sender, DirectEventArgs e)
        //{
        //    oldSportUsed.CopySport(sportUsed);
        //    sportUsed.ClearSport();
        //    LoadSportInForm(sportUsed);
        //}

        //protected void btnNuevo_DirectClick(object sender, DirectEventArgs e)
        //{
        //    X.Msg.Confirm("Atención", "¿Crear nuevo?", new JFunction("btnNuevo_Click(result);", "result")).Show();
        //}
                
        public void btnNuevo_Click()  //(object sender, DirectEventArgs e)
        {
            oldSportUsed.CopySport(sportUsed);
            sportUsed.ClearSport();
            LoadSportInForm(sportUsed);
        }


        protected void AskNuevo(object sender, DirectEventArgs e)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Atención",
                Message = "Continuamos?",
                Buttons = MessageBox.Button.YESNO,
                Icon = MessageBox.Icon.QUESTION,                
                Fn = new JFunction { Fn = "showResult" }
            });
        }

        [DirectMethod]
        public void DoYes()
        {
            oldSportUsed.CopySport(sportUsed);
            sportUsed.ClearSport();
            LoadSportInForm(sportUsed);
        }

        [DirectMethod]
        public void DoNo()
        {
        }


    }
}