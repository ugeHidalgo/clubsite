using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class SponsorTests
    {
        [TestMethod]
        public void TestSponsorConstructorWithoutData()
        {
            int aSponsorId=0;
            string aNombre=null;
            string aContactPerson = null;
            string aMobile = null;
            string aTlf = null;
            DateTime aRegDate=DateTime.Now;
            string aCondOfertadas = null;
            decimal anAportInicial = 0;
            decimal anAportRecibida = 0;
            string aWebURL = null;
            string anEMail = null;
            string aLogoURL = null;
            string anImageURL = null;
            bool activo=false;
            double aLatitud = 0;
            double aLongitud = 0;
            string aMemo = null;
            string aStreet = null;
            string aNumber = null;
            string aCity = null;
            string aCountry = null;
            string aPostalCode = null;

            Sponsor aSponsor = new Sponsor();

            Assert.AreEqual(aSponsorId, aSponsor.SponsorId);
            Assert.AreEqual(aNombre, aSponsor.Nombre);
            //Assert.AreEqual(null, aSponsor.Address);
            Assert.AreEqual(aStreet, aSponsor.Address.Street);
            Assert.AreEqual(aNumber, aSponsor.Address.Number);
            Assert.AreEqual(aCity, aSponsor.Address.City);
            Assert.AreEqual(aCountry, aSponsor.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor.Address.PostalCode);

            Assert.AreEqual(aContactPerson, aSponsor.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor.Mobile);
            Assert.AreEqual(aTlf, aSponsor.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor.WebURL);
            Assert.AreEqual(anEMail, aSponsor.EMail);
            Assert.AreEqual(aLogoURL, aSponsor.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor.ImageURL);
            Assert.AreEqual(activo, aSponsor.Activo);
            Assert.AreEqual(aLatitud, aSponsor.Latitud);
            Assert.AreEqual(aLongitud, aSponsor.Longitud);
            Assert.AreEqual(aMemo, aSponsor.Memo);
        }
        
        [TestMethod]
        public void TestSponsorConstructorWithData()
        {
            int aSponsorId = 10;
            string aNombre = "Name";            
            string aContactPerson = "Contact person";
            string aMobile = "999 929292";
            string aTlf = "555 676767";
            DateTime aRegDate = DateTime.Now;
            string aCondOfertadas = "Condiciones ofertadas";
            decimal anAportInicial = 400;
            decimal anAportRecibida = 200;
            string aWebURL = "www.weburl.com";
            string anEMail = "anemail@mail.com";
            string aLogoURL = "a logo URL";
            string anImageURL = " An image URL";
            bool activo = false;
            double aLatitud = 40.381090863719436;
            double aLongitud = -3.6222052574157715;
            string aMemo = "Observaciones varias";

            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);

            Sponsor aSponsor = new Sponsor(aSponsorId, aNombre, anAddress, aContactPerson, aMobile, aTlf, aRegDate, aCondOfertadas, anAportInicial,
                anAportRecibida, aWebURL, anEMail, aLogoURL, anImageURL, aLongitud, aLatitud, activo, aMemo);
                
            Assert.AreEqual(aSponsorId, aSponsor.SponsorId);
            Assert.AreEqual(aNombre, aSponsor.Nombre);
            Assert.AreEqual(aContactPerson, aSponsor.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor.Mobile);
            Assert.AreEqual(aTlf, aSponsor.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor.WebURL);
            Assert.AreEqual(anEMail, aSponsor.EMail);
            Assert.AreEqual(aLogoURL, aSponsor.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor.ImageURL);
            Assert.AreEqual(activo, aSponsor.Activo);
            Assert.AreEqual(aLatitud, aSponsor.Latitud);
            Assert.AreEqual(aLongitud, aSponsor.Longitud);
            Assert.AreEqual(aMemo, aSponsor.Memo);

            Assert.AreEqual(aStreet, aSponsor.Address.Street);
            Assert.AreEqual(aNumber, aSponsor.Address.Number);
            Assert.AreEqual(aCity, aSponsor.Address.City);
            Assert.AreEqual(aCountry, aSponsor.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor.Address.PostalCode);
        }

        [TestMethod]
        public void TestSetSponsor()
        {
            int aSponsorId = 10;
            string aNombre = "Name";
            string aContactPerson = "Contact person";
            string aMobile = "999 929292";
            string aTlf = "555 676767";
            DateTime aRegDate = DateTime.Now;
            string aCondOfertadas = "Condiciones ofertadas";
            decimal anAportInicial = 400;
            decimal anAportRecibida = 200;
            string aWebURL = "www.weburl.com";
            string anEMail = "anemail@mail.com";
            string aLogoURL = "a logo URL";
            string anImageURL = " An image URL";
            bool activo = false;
            double aLatitud = 40.381090863719436;
            double aLongitud = -3.6222052574157715;
            string aMemo = "Observaciones varias";

            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Sponsor aSponsor = new Sponsor();
            aSponsor.SetSponsor(aSponsorId, aNombre, anAddress, aContactPerson, aMobile, aTlf, aRegDate, aCondOfertadas, anAportInicial,
                anAportRecibida, aWebURL, anEMail, aLogoURL, anImageURL, aLongitud, aLatitud, activo, aMemo);

            Assert.AreEqual(aSponsorId, aSponsor.SponsorId);
            Assert.AreEqual(aNombre, aSponsor.Nombre);
            Assert.AreEqual(aContactPerson, aSponsor.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor.Mobile);
            Assert.AreEqual(aTlf, aSponsor.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor.WebURL);
            Assert.AreEqual(anEMail, aSponsor.EMail);
            Assert.AreEqual(aLogoURL, aSponsor.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor.ImageURL);
            Assert.AreEqual(activo, aSponsor.Activo);
            Assert.AreEqual(aLatitud, aSponsor.Latitud);
            Assert.AreEqual(aLongitud, aSponsor.Longitud);
            Assert.AreEqual(aMemo, aSponsor.Memo);

            Assert.AreEqual(aStreet, aSponsor.Address.Street);
            Assert.AreEqual(aNumber, aSponsor.Address.Number);
            Assert.AreEqual(aCity, aSponsor.Address.City);
            Assert.AreEqual(aCountry, aSponsor.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor.Address.PostalCode);
        }


        [TestMethod]
        public void TestClearSponsor()
        {
            int aSponsorId = 10;
            string aNombre = "Name";
            string aContactPerson = "Contact person";
            string aMobile = "999 929292";
            string aTlf = "555 676767";
            DateTime aRegDate = DateTime.Now;
            string aCondOfertadas = "Condiciones ofertadas";
            decimal anAportInicial = 400;
            decimal anAportRecibida = 200;
            string aWebURL = "www.weburl.com";
            string anEMail = "anemail@mail.com";
            string aLogoURL = "a logo URL";
            string anImageURL = " An image URL";
            bool activo = false;
            double aLatitud = 40.381090863719436;
            double aLongitud = -3.6222052574157715;
            string aMemo = "Observaciones varias";

            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Sponsor aSponsor = new Sponsor();
            aSponsor.SetSponsor(aSponsorId, aNombre, anAddress, aContactPerson, aMobile, aTlf, aRegDate, aCondOfertadas, anAportInicial,
                anAportRecibida, aWebURL, anEMail, aLogoURL, anImageURL, aLongitud, aLatitud, activo, aMemo);

            Assert.AreEqual(aSponsorId, aSponsor.SponsorId);
            Assert.AreEqual(aNombre, aSponsor.Nombre);
            Assert.AreEqual(aContactPerson, aSponsor.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor.Mobile);
            Assert.AreEqual(aTlf, aSponsor.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor.WebURL);
            Assert.AreEqual(anEMail, aSponsor.EMail);
            Assert.AreEqual(aLogoURL, aSponsor.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor.ImageURL);
            Assert.AreEqual(activo, aSponsor.Activo);
            Assert.AreEqual(aLatitud, aSponsor.Latitud);
            Assert.AreEqual(aLongitud, aSponsor.Longitud);
            Assert.AreEqual(aMemo, aSponsor.Memo);

            Assert.AreEqual(aStreet, aSponsor.Address.Street);
            Assert.AreEqual(aNumber, aSponsor.Address.Number);
            Assert.AreEqual(aCity, aSponsor.Address.City);
            Assert.AreEqual(aCountry, aSponsor.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor.Address.PostalCode);

            aSponsor.ClearSponsor();

            Assert.AreEqual(0, aSponsor.SponsorId);
            Assert.AreEqual(null, aSponsor.Nombre);
            Assert.AreEqual(null, aSponsor.Address);
            Assert.AreEqual(null, aSponsor.ContactPerson);
            Assert.AreEqual(null, aSponsor.Mobile);
            Assert.AreEqual(null, aSponsor.Tlf);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), aSponsor.RegDate.ToShortDateString());
            Assert.AreEqual(null, aSponsor.CondOfertadas);
            Assert.AreEqual(0, aSponsor.AportInicial);
            Assert.AreEqual(0, aSponsor.AportRecibida);
            Assert.AreEqual(null, aSponsor.WebURL);
            Assert.AreEqual(null, aSponsor.EMail);
            Assert.AreEqual(null, aSponsor.LogoURL);
            Assert.AreEqual(null, aSponsor.ImageURL);
            Assert.AreEqual(false, aSponsor.Activo);
            Assert.AreEqual(0, aSponsor.Latitud);
            Assert.AreEqual(0, aSponsor.Longitud);
            Assert.AreEqual(null, aSponsor.Memo);            
        }


        [TestMethod]
        public void TestCopySponsor()
        {
            int aSponsorId = 10;
            string aNombre = "Name";
            string aContactPerson = "Contact person";
            string aMobile = "999 929292";
            string aTlf = "555 676767";
            DateTime aRegDate = DateTime.Now;
            string aCondOfertadas = "Condiciones ofertadas";
            decimal anAportInicial = 400;
            decimal anAportRecibida = 200;
            string aWebURL = "www.weburl.com";
            string anEMail = "anemail@mail.com";
            string aLogoURL = "a logo URL";
            string anImageURL = " An image URL";
            bool activo = false;
            double aLatitud = 40.381090863719436;
            double aLongitud = -3.6222052574157715;
            string aMemo = "Observaciones varias";

            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Sponsor aSponsor1 = new Sponsor();
            aSponsor1.SetSponsor(aSponsorId, aNombre, anAddress, aContactPerson, aMobile, aTlf, aRegDate, aCondOfertadas, anAportInicial,
                anAportRecibida, aWebURL, anEMail, aLogoURL, anImageURL, aLongitud, aLatitud, activo, aMemo);

            Assert.AreEqual(aSponsorId, aSponsor1.SponsorId);
            Assert.AreEqual(aNombre, aSponsor1.Nombre);
            Assert.AreEqual(aContactPerson, aSponsor1.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor1.Mobile);
            Assert.AreEqual(aTlf, aSponsor1.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor1.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor1.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor1.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor1.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor1.WebURL);
            Assert.AreEqual(anEMail, aSponsor1.EMail);
            Assert.AreEqual(aLogoURL, aSponsor1.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor1.ImageURL);
            Assert.AreEqual(activo, aSponsor1.Activo);
            Assert.AreEqual(aLatitud, aSponsor1.Latitud);
            Assert.AreEqual(aLongitud, aSponsor1.Longitud);
            Assert.AreEqual(aMemo, aSponsor1.Memo);

            Assert.AreEqual(aStreet, aSponsor1.Address.Street);
            Assert.AreEqual(aNumber, aSponsor1.Address.Number);
            Assert.AreEqual(aCity, aSponsor1.Address.City);
            Assert.AreEqual(aCountry, aSponsor1.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor1.Address.PostalCode);

            Sponsor aSponsor2 = new Sponsor();
            aSponsor2.CopySponsor(aSponsor1);

            Assert.AreEqual(aSponsorId, aSponsor2.SponsorId);
            Assert.AreEqual(aNombre, aSponsor2.Nombre);
            Assert.AreEqual(aContactPerson, aSponsor2.ContactPerson);
            Assert.AreEqual(aMobile, aSponsor2.Mobile);
            Assert.AreEqual(aTlf, aSponsor2.Tlf);
            Assert.AreEqual(aMobile, aSponsor2.Mobile);
            Assert.AreEqual(aTlf, aSponsor2.Tlf);
            Assert.AreEqual(aRegDate.ToShortDateString(), aSponsor2.RegDate.ToShortDateString());
            Assert.AreEqual(aCondOfertadas, aSponsor2.CondOfertadas);
            Assert.AreEqual(anAportInicial, aSponsor2.AportInicial);
            Assert.AreEqual(anAportRecibida, aSponsor2.AportRecibida);
            Assert.AreEqual(aWebURL, aSponsor2.WebURL);
            Assert.AreEqual(anEMail, aSponsor2.EMail);
            Assert.AreEqual(aLogoURL, aSponsor2.LogoURL);
            Assert.AreEqual(anImageURL, aSponsor2.ImageURL);
            Assert.AreEqual(activo, aSponsor2.Activo);
            Assert.AreEqual(aLatitud, aSponsor2.Latitud);
            Assert.AreEqual(aLongitud, aSponsor2.Longitud);
            Assert.AreEqual(aMemo, aSponsor2.Memo);

            Assert.AreEqual(aStreet, aSponsor2.Address.Street);
            Assert.AreEqual(aNumber, aSponsor2.Address.Number);
            Assert.AreEqual(aCity, aSponsor2.Address.City);
            Assert.AreEqual(aCountry, aSponsor2.Address.Country);
            Assert.AreEqual(aPostalCode, aSponsor2.Address.PostalCode);            
        }
    }
}
