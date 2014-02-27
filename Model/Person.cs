using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ClubSite.Model
{
    public class Person
    {
        //Properties
        #region
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(200)]
        public string SecondName { get; set; }

        public Address Address { get; set; }

        [StringLength(15)]
        public string Tlf { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }
        

        #endregion

        //Constructors
        #region

        public Person()
        {

        }

        public Person(string aFirstName, string aSecondName, Address anAddress, string aTlf, string aMobile, string anEMail)
        {
            this.FirstName = aFirstName;
            this.SecondName = aSecondName;
            this.Address = anAddress;
            this.Tlf = aTlf;
            this.Mobile = aMobile;
            this.EMail = anEMail;            
        }

        #endregion

        //methods
        #region

        public void SetPerson(string aFirstName, string aSecondName, Address anAddress, string aTlf, string aMobile, string anEMail)
        {
            this.FirstName = aFirstName;
            this.SecondName = aSecondName;
            this.Address = anAddress;
            this.Tlf = aTlf;
            this.Mobile = aMobile;
            this.EMail = anEMail;
        }

        public void ClearPerson()
        {
            this.FirstName = null;
            this.SecondName = null;
            this.Address = null;
            this.Tlf = null;
            this.Mobile = null;
            this.EMail = null;            
        }

        public void CopyPerson(Person aPerson)
        {
            this.FirstName = aPerson.FirstName;
            this.SecondName = aPerson.SecondName;
            this.Address = aPerson.Address;
            this.Tlf = aPerson.Tlf;
            this.Mobile = aPerson.Mobile;
            this.EMail = aPerson.EMail;
        }

        #endregion
    }
}