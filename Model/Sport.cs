using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class Sport
    {
        //Properties
        #region
        public Int32 SportID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<RaceType> RaceTypes { get; set; }

        #endregion

        //Constructors
        #region
        public Sport()
        {
        }

        public Sport(Int32 anID, string aName, string aMemo)
        {
            this.SportID = anID;
            this.Name = aName;
            this.Memo = aMemo;
        }
        #endregion

        //Methods
        #region        
        public void SetSport(int anID, string aName, string aMemo)
        {
            this.SportID = anID;
            this.Name = aName;
            this.Memo = aMemo;
        }

        public void ClearSport()
        {
            this.SportID = 0;
            this.Name = null;
            this.Memo = null;
        }

        public void CopySport(Sport aSport)
        {
            this.SportID = aSport.SportID;
            this.Name = aSport.Name;
            this.Memo = aSport.Memo;
        }
        #endregion


    }
}