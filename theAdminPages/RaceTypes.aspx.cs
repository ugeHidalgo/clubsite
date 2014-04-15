using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubSite.Model;
using Ext.Net;

namespace ClubSite.AdminPages
{
    public partial class RaceTypes : System.Web.UI.Page
    {
        static RaceType rtUsed;
        static RaceType oldRtUsed;

        public void LoadRaceTypeInForm(RaceType aRaceType)
        {
            txbxId.Text = Convert.ToString(aRaceType.RaceTypeID);
            //txbxSportID.Text = Convert.ToString(aRaceType.SportID);
            if (aRaceType.SportID == 0)
                cbxDeportes.Value = "";
            else
            {
                object SportID = aRaceType.SportID;
                cbxDeportes.Select(SportID);
            }
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
                        X.Msg.Alert("Atención", "No hay ningún tipo de carrera registrada en la Base de datos.").Show();
                    }
                    oldRtUsed.CopyRaceType(rtUsed);
                    LoadRaceTypeInForm(rtUsed);

                    Store store = this.cbxDeportes.GetStore();
                    store.DataSource = from s in db.Sports select new { s.SportID, s.Name };
                    store.DataBind();
                }
            }
        }

        protected void GridPanel1_Cell_Click(object sender, EventArgs e)
        {
            try
            {
                CellSelectionModel sm = this.GridPanel1.GetSelectionModel() as CellSelectionModel;
                Int32 actualRtId = Convert.ToInt32(sm.SelectedCell.RecordID);
                using (var db = new ClubSiteContext())
                {
                    rtUsed = (from raceTypes in db.RaceTypes
                              orderby raceTypes.Name
                              where raceTypes.RaceTypeID == actualRtId
                              select raceTypes).FirstOrDefault();

                    if (rtUsed == null)
                        X.Msg.Alert("Atención", "No hay ningún tipo de carrera registrada en la Base de datos.").Show();
                    oldRtUsed.CopyRaceType(rtUsed);

                    //Loads model object data into form
                    LoadRaceTypeInForm(rtUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        [DirectMethod]
        public void AskNew()
        {
            X.Msg.Confirm("Atención", "¿Desea crear un nuevo tipo de competición?", new MessageBoxButtonsConfig
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
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Cancelada la creación de nuevo tipo de competición" });
        }

        [DirectMethod]
        public void DoNew()
        {
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Ficha para nuevo tipo de competición" });
            oldRtUsed.CopyRaceType(rtUsed);
            rtUsed.ClearRaceType();
            LoadRaceTypeInForm(rtUsed);
        }

        [DirectMethod]
        public void AskCancel()
        {
            X.Msg.Confirm("Atención", "¿Desea cancelar la edición del tipo de competición actual?", new MessageBoxButtonsConfig
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
            rtUsed.CopyRaceType(oldRtUsed);
            LoadRaceTypeInForm(rtUsed);
            GridPanel1.DataBind();
            btnBorrar.Enabled = true;
        }

        [DirectMethod]
        public void AskDel()
        {
            X.Msg.Confirm("Atención", "¿Desea borrar el tipo de carrera mostrada en la ficha?", new MessageBoxButtonsConfig
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
            Notification.Show(new NotificationConfig { Title = "Aviso", Icon = Icon.Information, Html = "Borrando el tipo de carrera en pantalla edición" });
            if (rtUsed.RaceTypeID == 0)
            { //No Race Type selected
                X.Msg.Alert("Atención", "No hay nada que borrar ya que no hay tipos de carrera registradas.").Show();
            }
            else
            {
                //Del racetype
                using (var db = new ClubSiteContext())
                {
                    RaceType item = (from racetypes in db.RaceTypes
                                     where racetypes.RaceTypeID == rtUsed.RaceTypeID
                                     select racetypes).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Tipo de carrera con id : {0} no encontrado", rtUsed.RaceTypeID));
                        X.Msg.Alert("Atención", "Tipo de carrera no encontrada. Borrado cancelado,").Show();
                        return;
                    }
                    db.RaceTypes.Remove(item);
                    db.SaveChanges();
                    this.Store1.DataBind();
                    X.Msg.Alert("Atención", "Tipo de carrera borrada.").Show();

                    //Load data for first race type
                    rtUsed = (from raceTypes in db.RaceTypes
                              orderby raceTypes.Name
                              select raceTypes).FirstOrDefault();
                    if (rtUsed == null)
                    {
                        //Last item was erased. No items in BD.
                        rtUsed = new RaceType();
                        X.Msg.Alert("Atención", "No queda ningún tipo de carrera registrada en la Base de datos.").Show();
                    }                    
                    oldRtUsed.CopyRaceType(rtUsed); 
                    //Loads model object data into form
                    LoadRaceTypeInForm(rtUsed);
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
            bool sigue = true;
            int points = 0;
            int aSportIDSelected = 0;
            string messageError = null;

            //Verify name exists
            if (txbxName.Text == "")
            {
                sigue = false;
                messageError = "Falta el nombre del tipo de carrera.";
            }

            //Verify points exists and are between 0 and 10.000
            if (sigue)
            {
                try
                {
                    points = Convert.ToInt32(txbxPuntos.Text);
                    if (points < 0 || points > 10000)
                    {
                        sigue = false;
                        messageError="Los puntos asignados deben ser un número entre 0 y 10.000";                    
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                    messageError="Debes asignar un valor numérico entre 0 y 10.000 para los puntos.";
                }
            }

            //Verify is a SportID was choosed.
            if (sigue)
            {
                try
                {
                    aSportIDSelected = Convert.ToInt32(cbxDeportes.SelectedItem.Value);//Convert.ToInt32(txbxSportID.Text);
                    if (aSportIDSelected <= 0)
                    {
                        sigue = false;                       
                       messageError="Escoje el tipo de deporte al que pertenece la carrera.";
                    }
                }
                catch (Exception)
                {
                    sigue = false;
                   messageError="Escoje el tipo de deporte al que pertenece la carrera.";
                }
            }

            //Save if conditions are ok.
            if (sigue)
            {
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
                    this.Store1.DataBind();
                    X.Msg.Alert("Atención", "Nuevo tipo de carrera grabada.").Show();
                }
                btnBorrar.Enabled = true;
            }
            else
            {
                X.Msg.Alert("Atención", messageError).Show();
            }
           
        }

        protected void Store2_ReadData(object sender, StoreReadDataEventArgs e)
        {
            using (var db = new ClubSiteContext())
            {
                Store store = this.cbxDeportes.GetStore();
                store.DataSource = from s in db.Sports select new { s.SportID, s.Name };
                store.DataBind();
            }
        }

    }
}