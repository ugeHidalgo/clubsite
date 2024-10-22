﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSite.Model
{
    public class Member : Person
    {
        //Properties
        #region
        [Key, StringLength(25)]
        public string UserName { get; set; }

        public string Number { get; set; }

        [StringLength(15)]
        public string DNI { get; set; }

        public bool State { get; set; }

        public bool Federated { get; set; }

        public bool Visible { get; set; }

        [Required,
        DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [StringLength(250)]
        public string Memo { get; set; }

        public string ImageURL { get; set; }

        public string NImageURL { get; set; }

        public string BlogURL { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        #endregion

        //Constructors
        #region
        public Member()
        {
            this.RegDate = DateTime.Now;
            this.State = false;
            this.Federated = false;
            this.Visible = false;
        }

        public Member(string anUserName, string aNumber, string aFirstName, string aSecondName, string aDNI, Address anAddress, string aTlf, string aMobile,
                      string anEMail, bool aState, bool federated, bool visible, DateTime? aBirthDate, string aMemo, string anImageURL, string aNImageURL, string aBlogURL)
        {
            this.UserName = anUserName;
            this.Number = aNumber;
            this.FirstName = aFirstName;
            this.SecondName = aSecondName;
            this.DNI = aDNI;
            this.Address = anAddress;
            this.Tlf = aTlf;
            this.Mobile = aMobile;
            this.EMail = anEMail;
            this.State = aState;
            this.Federated = federated;
            this.Visible = visible;
            this.RegDate = DateTime.Now;
            this.BirthDate = aBirthDate;
            this.Memo = aMemo;
            this.ImageURL = anImageURL;
            this.NImageURL = aNImageURL;
            this.BlogURL = aBlogURL;
        }
        #endregion

        //Methods
        #region
        public void SetMember(string anUserName, string aNumber, string aFirstName, string aSecondName, string aDNI, Address anAddress, string aTlf, string aMobile,
                              string anEMail, bool aState, bool federated, bool visible, DateTime? aBirthDate, string aMemo, string anImageURL, string aNImageURL,
                              string aBlogURL)
        {
            this.UserName = anUserName;
            this.Number = aNumber;
            this.FirstName = aFirstName;
            this.SecondName = aSecondName;
            this.DNI = aDNI;
            this.Address = anAddress;
            this.Tlf = aTlf;
            this.Mobile = aMobile;
            this.EMail = anEMail;
            this.State = aState;
            this.Federated = federated;
            this.Visible = visible;
            this.BirthDate = aBirthDate;
            this.Memo = aMemo;
            this.ImageURL = anImageURL;
            this.NImageURL = aNImageURL;
            this.BlogURL = aBlogURL;
        }

        public void ClearMember()
        {
            this.UserName = null;
            this.Number = null;
            this.FirstName = null;
            this.SecondName = null;
            this.DNI = null;
            this.Address = null;
            this.Tlf = null;
            this.Mobile = null;
            this.EMail = null;
            this.State = false;
            this.Federated = false;
            this.Visible = false;
            this.RegDate = DateTime.Now;
            this.BirthDate = null;
            this.Memo = null;
            this.ImageURL = null;
            this.NImageURL = null;
            this.BlogURL = null;
        }

        public void CopyMember(Member aMember)
        {
            this.UserName = aMember.UserName;
            this.Number = aMember.Number;
            this.FirstName = aMember.FirstName;
            this.SecondName = aMember.SecondName;
            this.DNI = aMember.DNI;
            if (aMember.Address == null)
            {
                this.Address = null;
            }
            else
            {
                this.Address = new Address (aMember.Address.Street, aMember.Address.Number, aMember.Address.PostalCode,
                                            aMember.Address.Country, aMember.Address.City );
            }
            this.Tlf = aMember.Tlf;
            this.Mobile = aMember.Mobile;
            this.EMail = aMember.EMail;
            this.State = aMember.State;
            this.Federated = aMember.Federated;
            this.Visible = aMember.Visible;
            this.RegDate = aMember.RegDate;
            this.BirthDate = aMember.BirthDate;
            this.Memo = aMember.Memo;
            this.ImageURL = aMember.ImageURL;
            this.NImageURL = aMember.NImageURL;
            this.BlogURL = aMember.BlogURL;
        }

        #endregion
    }
}
