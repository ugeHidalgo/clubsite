using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSite.Model
{
    public class Sponsor
    {
        //Properties
        #region

        [Key]
        public int SponsorId { get; set; }
        
        [Required, StringLength(100)]
        public string Nombre { get; set; }
        
        public Address Address { get; set; }

        [StringLength(200)]
        public string ContactPerson { get; set; }

        public string Mobile { get; set; }

        public string Tlf { get; set; }
        
        [Required]
        public DateTime RegDate { get; set; }
        
        [StringLength(250)]
        public string CondOfertadas { get; set; }
                
        public decimal AportInicial { get; set; }
        
        public decimal AportRecibida { get; set; }
        
        public string WebURL { get; set; }

        public string EMail { get; set; }
        
        public string LogoURL { get; set; }
        
        public string ImageURL { get; set; }
              
        public bool Activo { get; set; }
        
        public string Memo { get; set; }

        #endregion

         //Constructors
        #region
        public Sponsor()
        {
            Address anAddress = new Address();
            this.RegDate = DateTime.Now;
            this.Address = anAddress;
        }

        public Sponsor(int aSponsorId, string aNombre, Address anAddress, string aContactPerson, string aMobile, string aTlf, DateTime aRegDate, 
            string aCondOfertadas, decimal anAportInicial, decimal anAportRecibida, string aWebURL, string anEMail, string aLogoURL, string anImageURL, 
            bool activo, string aMemo)
        {
            this.SponsorId = aSponsorId;
            this.Nombre = aNombre;
            this.Address = anAddress;
            this.ContactPerson= aContactPerson;
            this.Mobile = aMobile;
            this.Tlf = aTlf;
            this.RegDate = aRegDate;
            this.CondOfertadas = aCondOfertadas;
            this.AportInicial = anAportInicial;
            this.AportRecibida = anAportRecibida;
            this.WebURL = aWebURL;
            this.EMail = anEMail;
            this.LogoURL = aLogoURL;
            this.ImageURL = anImageURL;
            this.Activo = activo;
            this.Memo = aMemo;
        }


        #endregion

        //Methods
        #region 
        public void SetSponsor(int aSponsorId, string aNombre, Address anAddress, string aContactPerson, string aMobile, string aTlf, DateTime aRegDate,  
            string aCondOfertadas, decimal anAportInicial, decimal anAportRecibida, string aWebURL, string anEMail, string aLogoURL, string anImageURL, 
            bool activo, string aMemo)
        {
            this.SponsorId = aSponsorId;
            this.Nombre = aNombre;
            this.Address = anAddress;
            this.ContactPerson = aContactPerson;
            this.Mobile = aMobile;
            this.Tlf = aTlf;
            this.RegDate = aRegDate;
            this.CondOfertadas = aCondOfertadas;
            this.AportInicial = anAportInicial;
            this.AportRecibida = anAportRecibida;
            this.WebURL = aWebURL;
            this.EMail = anEMail;
            this.LogoURL = aLogoURL;
            this.ImageURL = anImageURL;
            this.Activo = activo;
            this.Memo = aMemo;
        }

        public void ClearSponsor()
        {
            this.SponsorId = 0;
            this.Nombre = null;
            this.Address = null;
            this.ContactPerson = null;
            this.Mobile = null;
            this.Tlf = null;
            this.RegDate = DateTime.Now;
            this.CondOfertadas = null;
            this.AportInicial = 0;
            this.AportRecibida = 0;
            this.WebURL = null;
            this.EMail = null;
            this.LogoURL = null;
            this.ImageURL = null;
            this.Activo = false;
            this.Memo = null;
        }

        public void CopySponsor(Sponsor aSponsor1)
        {
            this.SponsorId = aSponsor1.SponsorId;
            this.Nombre = aSponsor1.Nombre;
            this.Address = aSponsor1.Address;
            this.ContactPerson = aSponsor1.ContactPerson;
            this.Mobile = aSponsor1.Mobile;
            this.Tlf = aSponsor1.Tlf;
            this.RegDate = aSponsor1.RegDate;
            this.CondOfertadas = aSponsor1.CondOfertadas;
            this.AportInicial = aSponsor1.AportInicial;
            this.AportRecibida = aSponsor1.AportRecibida;
            this.WebURL = aSponsor1.WebURL;
            this.EMail = aSponsor1.EMail;
            this.LogoURL = aSponsor1.LogoURL;
            this.ImageURL = aSponsor1.ImageURL;
            this.Activo = aSponsor1.Activo;
            this.Memo = aSponsor1.Memo;
        }

        #endregion
    }
}
