using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSite.Model
{
    public class Address
    {
        //Properties
        #region
        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(7)]
        public string PostalCode { get; set; }

        #endregion

        //Constructors
        #region
        public Address()
        {
            this.Street = null;
            this.Number = null;
            this.City = null;
            this.Country = null;
            this.PostalCode = null;
        }

        public Address(string aStreet, string aNumber, string aCity, string aCountry, string aPostalCode)
        {
            this.Street = aStreet;
            this.Number = aNumber;
            this.City = aCity;
            this.Country = aCountry;
            this.PostalCode = aPostalCode;
        }

        #endregion

        //methods
        #region
        public void SetAddress(string aStreet, string aNumber, string aCity, string aCountry, string aPostalCode)
        {
            this.Street = aStreet;
            this.Number = aNumber;
            this.City = aCity;
            this.Country = aCountry;
            this.PostalCode = aPostalCode;
        }

        public void ClearAddress()
        {
            this.Street = null;
            this.Number = null;
            this.City = null;
            this.Country = null;
            this.PostalCode = null;
        }

        #endregion

    }
}
