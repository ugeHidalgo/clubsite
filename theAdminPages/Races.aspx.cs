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
        static Race rUsed;
        static Race oldRUsed;

        public IQueryable<Race> ddlRaces_GetData()
        {
            var db = new ClubSiteContext();
            IQueryable<Race> query = from races in db.Races
                                     orderby races.RaceDate descending, races.Name
                                     select races;
            return query;
        }
        public IQueryable ddlRaceTypes_GetData()
        {
            var db = new ClubSiteContext();
            var query = from rt in db.RaceTypes
                        join s in db.Sports on rt.SportID equals s.SportID
                        orderby s.Name, rt.Name
                        select new { rt.RaceTypeID, Name = (s.Name + " / " + rt.Name) };
            return query;
        }
        public IQueryable dllMembers_GetData()
        {
            var db = new ClubSiteContext();
            IQueryable query = from m in db.Members
                               orderby m.SecondName
                               select new { aMember = (m.SecondName + ", " + m.FirstName), m.UserName };
            return query;
        }


        private void LoadRaceInForm(Race aRace)
        {
            txbxID.Text = Convert.ToString(aRace.Id);
            txbxName.Text = aRace.Name;
            txbxDate.Text = aRace.RaceDate.ToShortDateString();
            txbxRaceTypeID.Text = Convert.ToString(aRace.RaceTypeId);
            ListItem aValue = ddlRaceTypes.Items.FindByValue(txbxRaceTypeID.Text);
            ddlRaceTypes.SelectedIndex = ddlRaceTypes.Items.IndexOf(aValue);

            if (aRace.Address == null)
            {
                txbxStreet.Text = null;
                txbxCity.Text = null;
                txbxPostalCode.Text = null;
                txbxCountry.Text = null;
                txbxNumber.Text = null;
            }
            else
            {
                txbxStreet.Text = aRace.Address.Street;
                txbxCity.Text = aRace.Address.City;
                txbxPostalCode.Text = aRace.Address.PostalCode;
                txbxCountry.Text = aRace.Address.Country;
                txbxNumber.Text = aRace.Address.Number;
            }
            txbxMemo.Text = aRace.Memo;

            //TO DO : Select members taken part in race with ID aRace.Id, and populate lbClubbersTakenPart

            //TO DO : Search points asigned to race an put on txbxPoints
        }
        private Race LoadRaceFromForm()
        {
            Race aRace = new Race();

            aRace.Id = Convert.ToInt32(txbxID.Text);
            aRace.Name = txbxName.Text;
            aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
            aRace.RaceTypeId = Convert.ToInt32(txbxRaceTypeID.Text);
            aRace.Address.Street = txbxStreet.Text;
            aRace.Address.City = txbxCity.Text;
            aRace.Address.PostalCode = txbxPostalCode.Text;
            aRace.Address.Country = txbxCountry.Text;
            aRace.Address.Number = txbxNumber.Text;
            aRace.Memo = txbxMemo.Text;

            return aRace;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rUsed = new Race();
                oldRUsed = new Race();
                using (var db = new ClubSiteContext())
                {
                    rUsed = (from races in db.Races
                             orderby races.RaceDate descending, races.Name
                             select races).FirstOrDefault();

                    if (rUsed == null)
                    {
                        rUsed = new Race();
                        Response.Write("<script>alert('No hay ningúna carrera registrada en la Base de datos.')</script>");
                    }
                    oldRUsed.CopyRace(rUsed);
                    LoadRaceInForm(rUsed);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            oldRUsed.CopyRace(rUsed);
            rUsed.ClearRace();
            LoadRaceInForm(rUsed);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            bool sigue = true;
            int aRaceIDSelected = 0;
            string messageError = null;

            //Verify name exists
            if (txbxName.Text == "")
            {
                sigue = false;
                messageError = "<script>alert('Falta el nombre de la carrera')</script>";
            }

            //Verify is a RaceTypeID was choosed.
            if (sigue)
            {
                aRaceIDSelected = Convert.ToInt32(txbxRaceTypeID.Text);
                if (aRaceIDSelected == 0)
                {
                    sigue = false;
                    messageError = "<script>alert('Escoje un tipo de carrera.')</script>";
                }
            }

            //Save if conditions are ok.
            if (sigue)
            {                
                using (var db = new ClubSiteContext())
                {
                    Race aRace;
                    if (rUsed.Id == 0)
                    { //New Race
                        aRace = new Race();
                        aRace.Name = txbxName.Text;
                        aRace.Name = txbxName.Text;
                        aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
                        aRace.RaceTypeId = Convert.ToInt32(txbxRaceTypeID.Text);
                        Address anAddres = new Address(txbxStreet.Text, txbxNumber.Text, txbxCity.Text, txbxCountry.Text, txbxPostalCode.Text);
                        aRace.Address = anAddres;                        
                        aRace.Memo = txbxMemo.Text;
                        db.Races.Add(aRace);
                    }
                    else
                    { //Update actual Race
                        aRace = (from races in db.Races
                                     where races.Id == rUsed.Id
                                     select races).FirstOrDefault();
                        if (aRace == null)
                        {
                            // The item wasn't found
                            ModelState.AddModelError("", String.Format("Carrera con Id : {0} no encontrada", rUsed.Id));
                            return;
                        }
                        aRace.Name = txbxName.Text;
                        aRace.RaceDate = Convert.ToDateTime(txbxDate.Text);
                        aRace.RaceTypeId = Convert.ToInt32(txbxRaceTypeID.Text);
                        Address anAddres = new Address(txbxStreet.Text,txbxNumber.Text,txbxCity.Text,txbxCountry.Text,txbxPostalCode.Text);
                        aRace.Address = anAddres;                        
                        aRace.Memo = txbxMemo.Text;
                    }
                    db.SaveChanges();
                    LoadRaceInForm(aRace);  //To update the ID (identity file)                                  
                    rUsed.CopyRace(aRace);
                    oldRUsed.CopyRace(rUsed);
                    gvRaces.DataBind();
                    Response.Write("<script>alert('Nueva carrera grabada')</script>");
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
            rUsed.CopyRace(oldRUsed);
            LoadRaceInForm(rUsed);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (rUsed.Id == 0)
            { //No Race Type selected
                Response.Write(@"<script>alert('No hay nada que borrar ya que no hay carreras registradas.')</script>");
            }
            else
            {
                using (var db = new ClubSiteContext())
                {
                    Race item = (from race in db.Races
                                 where race.Id == rUsed.Id
                                 select race).FirstOrDefault();
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Carrera con id : {0} no encontrada", rUsed.Id));
                        return;
                    }
                    db.Races.Remove(item);
                    db.SaveChanges();                    
                    gvRaces.DataBind();

                    try
                    {
                        //Select the id for the race.            
                        Int32 actualRId = Convert.ToInt32(gvRaces.SelectedRow.Cells[1].Text);

                        //Search for the Race and load into model object.
                        rUsed = (from races in db.Races
                                 orderby races.RaceDate descending, races.Name
                                 select races).FirstOrDefault();

                        if (rUsed == null)
                        {
                            rUsed = new Race();
                            Response.Write("<script>alert('No queda ninguna carrera registrada en la Base de datos.')</script>");
                        }
                    }
                    catch (Exception)
                    {
                        //Last object was deleted, search for new object if it exists
                        try
                        {
                            //Select the id for the race type.            
                            gvRaces.SelectedIndex = gvRaces.Rows.Count - 1;
                            Int32 actualRtId = Convert.ToInt32(gvRaces.SelectedRow.Cells[1].Text);

                            //Search for the RaceType and load into model object.
                            rUsed = (from races in db.Races
                                     orderby races.RaceDate descending, races.Name
                                     select races).FirstOrDefault();

                            if (rUsed == null)
                            {
                                rUsed = new Race();
                                Response.Write("<script>alert('No queda ninguna carrera registrada en la Base de datos.')</script>");
                            }
                        }
                        catch (Exception)
                        {
                            rUsed = new Race();
                            Response.Write("<script>alert('No queda ninguna carrera registrada en la Base de datos.')</script>");
                        }
                    }
                    oldRUsed.CopyRace(rUsed);
                    //Loads model object data into form
                    LoadRaceInForm(rUsed);
                }
            }
        }

        protected void gvRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Select the id for the race.            
                Int32 actualRId = Convert.ToInt32(gvRaces.SelectedRow.Cells[1].Text);

                //Search for the Race and load into model object.
                using (var db = new ClubSiteContext())
                {
                   rUsed = (from races in db.Races
                             orderby races.RaceDate descending, races.Name
                             where races.Id == actualRId
                             select races).FirstOrDefault();

                    if (rUsed == null)
                        Response.Write("<script>alert('No hay ningúna carrera registrada en la Base de datos.')</script>");
                    oldRUsed.CopyRace(rUsed);

                    //Loads model object data into form
                    LoadRaceInForm(rUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        protected void ddlRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Select the id for the race.            
                Int32 actualRId =Convert.ToInt32(ddlRaces.SelectedValue);

                //Search for the Race and load into model object.
                using (var db = new ClubSiteContext())
                {
                    rUsed = (from races in db.Races
                             orderby races.RaceDate descending, races.Name
                             where races.Id == actualRId
                             select races).FirstOrDefault();

                    if (rUsed == null)
                        Response.Write("<script>alert('No hay ningúna carrera registrada en la Base de datos.')</script>");
                    oldRUsed.CopyRace(rUsed);

                    //Loads model object data into form
                    LoadRaceInForm(rUsed);
                }
            }
            catch (Exception) { }
            btnBorrar.Enabled = true;
        }

        protected void ddlRaceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbxRaceTypeID.Text = Convert.ToString(ddlRaceTypes.SelectedValue);
        }

        protected void ddlRaceTypes_DataBound(object sender, EventArgs e)
        {
            //Loads data for the comobo box for the firts load.
            ListItem aValue = ddlRaceTypes.Items.FindByValue(txbxRaceTypeID.Text);
            ddlRaceTypes.SelectedIndex = ddlRaceTypes.Items.IndexOf(aValue);
        }

        protected void btnAddClubber_Click(object sender, EventArgs e)
        {
            bool sigue = true;
            string messageError = "";

            //Verify reace exists           
            if (txbxID.Text == "0")
            {
                sigue = false;
                messageError = "<script>alert('Graba primero los datos de la carrera')</script>";
            }

            if (sigue)
            {
                //Save data of clubber/race
                String memberUserName = ddlMembers.SelectedValue;               
                ListItem memberName = ddlMembers.SelectedItem;                
                lbClubbersTakingPart.Items.Add(memberName);
            }
            else
            {
                Response.Write(messageError);
            }
        }

        protected void btnDelClubber_Click(object sender, EventArgs e)
        {

        }
    }
}