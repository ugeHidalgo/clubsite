using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class RaceType
    {
        //Properties
        #region
        public Int32 RaceTypeID {get; set;}

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        public string Memo { get; set; }

        public Int32 SportID { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual ICollection<Race> Races { get; set; }

        #endregion

        //Constructors
        #region
        public RaceType()
        {
        }

        public RaceType(Int32 anID, string aName, int aPoints, string aMemo, Int32 aSportID)
        {
            this.RaceTypeID = anID;
            this.Name = aName;
            this.Points = aPoints;
            this.Memo = aMemo;
            this.SportID = aSportID;
        }
        #endregion

        //Methods
        #region
        public void SetRaceType(int anID, string aName, int points, string aMemo, Int32 aSportID)
        {
            this.RaceTypeID = anID;
            this.Name = aName;
            this.Points = points;
            this.Memo = aMemo;
            this.SportID = aSportID;
        }

        public void ClearRaceType()
        {
            this.RaceTypeID = 0;
            this.Name = null;
            this.Points = 0;
            this.Memo = null;
            this.SportID = 0;
        }

        public void CopyRaceType(RaceType aRaceType)
        {
            this.RaceTypeID = aRaceType.RaceTypeID;
            this.Name = aRaceType.Name;
            this.Points = aRaceType.Points;
            this.Memo = aRaceType.Memo;
            this.SportID = aRaceType.SportID;
        }
        #endregion


    }
}