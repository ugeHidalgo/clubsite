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
        [Key]
        public Int32 Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required] 
         //,DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RaceDate { get; set; }

        public Int32 RaceTypeID { get; set; }

        public virtual RaceType RaceType { get; set; }

        public Address Address { get; set; }

        public string Memo { get; set; }

        public string ImageURL { get; set; }

        public double Longitud { get; set; }

        public double Latitud { get; set; }

        public int PartMasc { get; set; }

        public int PartFem { get; set; }        

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<RaceAgeGroup> RaceAgeGroups { get; set; }

        #endregion


        //Constructors
        #region
        public Race()
        {
            this.RaceDate = DateTime.Now;
            PartFem = 0;
            PartMasc = 0;
        }

        public Race(int anID, string aName, DateTime aRaceDate, Model.Address anAddress, int aRaceTypeId, string aMemo,
                    string anImageURL, double aLongitud, double aLatitud, int aPartMasc, int aPartFem)
        {
            this.Id = anID;
            this.Name = aName;
            this.RaceDate = aRaceDate;
            this.Address = anAddress;
            this.RaceTypeID = aRaceTypeId;
            this.Memo = aMemo;
            this.ImageURL = anImageURL;
            this.Latitud = aLatitud;
            this.Longitud = aLongitud;
            this.PartFem = aPartFem;
            this.PartMasc = aPartMasc;
        }
        
        #endregion
                

        //Methods
        #region   
        public void SetRace(int anID, string aName, DateTime aRaceDate, Model.Address anAddress, int aRaceTypeId, string aMemo,
                            string anImageURL, double aLongitud, double aLatitud, int aPartMasc, int aPartFem)
        {
            this.Id = anID;
            this.Name = aName;
            this.RaceDate = aRaceDate;
            this.Address = anAddress;
            this.RaceTypeID = aRaceTypeId;
            this.Memo = aMemo;
            this.ImageURL = anImageURL;
            this.Latitud = aLatitud;
            this.Longitud = aLongitud;
            this.PartMasc = aPartMasc;
            this.PartFem = aPartFem;
        }

        public void ClearRace()
        {
            this.Id = 0;
            this.Name = null;
            this.RaceDate = DateTime.Now;
            this.Address = null;
            this.RaceTypeID = 0;
            this.Memo = null;
            this.ImageURL = null;
            this.Longitud = 0;
            this.Latitud = 0;
            this.PartFem = 0;
            this.PartMasc = 0;
        }

        public void CopyRace(Race aRace)
        {
            this.Id = aRace.Id;
            this.Name = aRace.Name;
            this.RaceDate = aRace.RaceDate;
            this.Address = aRace.Address;
            this.RaceTypeID = aRace.RaceTypeID;
            this.Memo = aRace.Memo;
            this.ImageURL = aRace.ImageURL;
            this.Latitud = aRace.Latitud;
            this.Longitud = aRace.Longitud;
            this.PartFem = aRace.PartFem;
            this.PartMasc = aRace.PartMasc;
        }

        #endregion

        public void AddMemberToRace(Member aMember)
        {

            this.Members.Add(aMember);
        }
    }
}