using System;
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

        [StringLength(15)]
        public string DNI { get; set; }

        public bool State { get; set; }

        public bool Federated { get; set; }

        public bool Visible { get; set; }

        [Required,
        DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }

        [ DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
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

        public Member(string anUserName, string aFirstName, string aSecondName, string aDNI, Address anAddress, string aTlf, string aMobile, 
                      string anEMail, bool aState, bool federated, bool visible, DateTime? aBirthDate, string aMemo, string anImageURL, string aNImageURL, string aBlogURL)
        {
            this.UserName = anUserName;
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
        public void SetMember(string anUserName, string aFirstName, string aSecondName, string aDNI, Address anAddress, string aTlf, string aMobile,
                              string anEMail, bool aState, bool federated, bool visible, DateTime? aBirthDate, string aMemo, string anImageURL, string aNImageURL, string aBlogURL)
        {
            this.UserName = anUserName;
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
        #endregion
    }
}
