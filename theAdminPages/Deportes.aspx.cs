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
                        X.Msg.Alert("Atención", "No hay ningún tipo de deporte registrado en la Base de datos.").Show();
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
                        X.Msg.Alert("Atención", "No hay ningún tipo de deporte registrado en la Base de datos.").Show();
                    }
                    oldSportUsed.CopySport(sportUsed);
                    LoadSportInForm(sportUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        [DirectMethod]
        public void AskDel()
        {
            X.Msg.Confirm("Atención", "¿Desea borrar el deporte mostrado en la ficha?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoDel()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNoDel()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNoDel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Se ha cancelado el borrado." });
        }

        [DirectMethod]
        public void DoDel()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Borrando el deporte en pantalla edición" });
            if (sportUsed.SportID == 0)
            { //No sport selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay deportes registrados en la base de datos.").Show();
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
                        X.Msg.Alert("Atención", "Deporte no encontrado. Borrado cancelado,").Show();
                        return;
                    }
                    db.Sports.Remove(item);
                    db.SaveChanges();
                    this.Store1.DataBind();
                    X.Msg.Alert("Atención", "Tipo de carrera borrada.").Show();

                    //Load data for first race type
                    sportUsed = (from sports in db.Sports
                                 orderby sports.Name
                                 select sports).FirstOrDefault();
                    if (sportUsed == null)
                    {
                        //Last item was erased. No items in BD.
                        sportUsed = new Sport();
                        X.Msg.Alert("Atención", "No queda ningún deporte registrado en la Base de datos.").Show();
                    }
                    oldSportUsed.CopySport(sportUsed);
                    //Loads model object data into form
                    LoadSportInForm(sportUsed);                    
                }
            }
        }
         

        [DirectMethod]
        public void AskSave()
        {
            X.Msg.Confirm("Atención", "¿Grabamos los datos en pantalla?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoSave()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNoSave()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNoSave()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Grabación Cancelada" });
        }

        [DirectMethod]
        public void DoSave()
        {            
            //Verify conditions
            if (txfName.Text == "")
            {                
                X.Msg.Alert("Atención", "Falta el nombre del deporte.").Show();
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
                            X.Msg.Alert("Atención", "Deporte no encontrado. Grabado cancelado.").Show();
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
                    X.Msg.Alert("Atención", "Datos de deporte grabados.").Show();                    
                }
                btnBorrar.Enabled = true;
            }
        }


        [DirectMethod]
        public void AskCancel()
         {
             X.Msg.Confirm("Atención", "¿Desea cancelar la edición del deporte actual?", new MessageBoxButtonsConfig
             {
                 Yes = new MessageBoxButtonConfig
                 {
                     Handler = "App.direct.DoCancel()",
                     Text = "Si"
                 }
                 ,
                 No = new MessageBoxButtonConfig
                 {
                     Handler = "App.direct.DoNoCancel()",
                     Text = "No"
                 }
             }).Show();
         }

        [DirectMethod]
        public void DoNoCancel()
         {
             Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Puede continuar la edicion." });
         }

        [DirectMethod]
        public void DoCancel()
         {
             Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la edición" });
             sportUsed.CopySport(oldSportUsed);
             LoadSportInForm(sportUsed);
             GridPanel1.DataBind();
             btnBorrar.Enabled = true;
         }

        [DirectMethod]
        public void AskNew()
        {
            X.Msg.Confirm("Atención", "¿Desea crear un nuevo deporte?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNew()",
                    Text = "Si"
                }
                ,
                No = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.DoNoNew()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void DoNoNew()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la creación de nuevo deporte" });
        }

        [DirectMethod]
        public void DoNew()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Ficha para nuevo deporte" });
            oldSportUsed.CopySport(sportUsed);
            sportUsed.ClearSport();
            LoadSportInForm(sportUsed);
        }
    }
}