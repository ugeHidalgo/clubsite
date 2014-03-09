using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class Race
    {
        //Properties
        #region
        public Int32 Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required] 
         //,DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RaceDate { get; set; }

        public Int32 RaceTypeId { get; set; }

        public Address Address { get; set; }

        public string Memo { get; set; }

        public virtual RaceType RaceType { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        #endregion


        //Constructors
        #region
        public Race()
        {
            this.RaceDate = DateTime.Now;
        }

        public Race(int anID, string aName, DateTime aRaceDate, Model.Address anAddress, int aRaceTypeId, string aMemo)
        {
            this.Id = anID;
            this.Name = aName;
            this.RaceDate = aRaceDate;
            this.Address = anAddress;
            this.RaceTypeId = aRaceTypeId;
            this.Memo = aMemo;
        }
        
        #endregion
                

        //Methods
        #region   
        public void SetRace(int anID, string aName, DateTime aRaceDate, Model.Address anAddress, int aRaceTypeId, string aMemo)
        {
            this.Id = anID;
            this.Name = aName;
            this.RaceDate = aRaceDate;
            this.Address = anAddress;
            this.RaceTypeId = aRaceTypeId;
            this.Memo = aMemo;
        }

        public void ClearRace()
        {
            this.Id = 0;
            this.Name = null;
            this.RaceDate = DateTime.Now;
            this.Address = null;
            this.RaceTypeId = 0;
            this.Memo = null;
        }

        public void CopyRace(Race aRace)
        {
            this.Id = aRace.Id;
            this.Name = aRace.Name;
            this.RaceDate = aRace.RaceDate;
            this.Address = aRace.Address;
            this.RaceTypeId = aRace.RaceTypeId;
            this.Memo = aRace.Memo;
        }

        #endregion
    }
}