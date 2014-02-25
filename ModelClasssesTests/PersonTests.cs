using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class PersonTests
    {       
        [TestMethod]
        public void TestPersonConstructorWithoutData()
        {
            string aFirstName = null;
            string aSecondName = null;
            string aTlf = null;
            string aMobile = null;
            string anEMail = null;
            
            Person aPerson = new Person();

            Assert.AreEqual(aFirstName, aPerson.FirstName);
            Assert.AreEqual(aSecondName, aPerson.SecondName);
            Assert.AreEqual(null, aPerson.Address);
            Assert.AreEqual(aTlf, aPerson.Tlf);
            Assert.AreEqual(aMobile, aPerson.Mobile);
            Assert.AreEqual(anEMail, aPerson.EMail);
        }

        [TestMethod]
        public void TestPersonConstructorWithData()
        {
            string aFirstName = "FirstName";
            string aSecondName = "SeconName";            
            string aStreet = "Street";
            string aNumber = "Number";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "PostalCode";
            string aTlf = "TLF";
            string aMobile = "Mobile";
            string anEMail = "eMail";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Person aPerson = new Person(aFirstName,aSecondName,anAddress,aTlf,aMobile,anEMail);

            Assert.AreEqual(aFirstName, aPerson.FirstName);
            Assert.AreEqual(aSecondName, aPerson.SecondName);
            Assert.AreEqual(aStreet, aPerson.Address.Street);
            Assert.AreEqual(aNumber, aPerson.Address.Number);
            Assert.AreEqual(aCity, aPerson.Address.City);
            Assert.AreEqual(aCountry, aPerson.Address.Country);
            Assert.AreEqual(aPostalCode, aPerson.Address.PostalCode);
            Assert.AreEqual(aTlf, aPerson.Tlf);
            Assert.AreEqual(aMobile, aPerson.Mobile);
            Assert.AreEqual(anEMail, aPerson.EMail);
        }

        [TestMethod]
        public void TestSetPerson()
        {
            string aFirstName = "FirstName";
            string aSecondName = "SeconName";            
            string aStreet = "Street";
            string aNumber = "Number";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "PostalCode";
            string aTlf = "TLF";
            string aMobile = "Mobile";
            string anEMail = "eMail";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Person aPerson = new Person();
            aPerson.SetPerson(aFirstName,aSecondName,anAddress,aTlf,aMobile,anEMail);

            Assert.AreEqual(aFirstName, aPerson.FirstName);
            Assert.AreEqual(aSecondName, aPerson.SecondName);
            Assert.AreEqual(aStreet, aPerson.Address.Street);
            Assert.AreEqual(aNumber, aPerson.Address.Number);
            Assert.AreEqual(aCity, aPerson.Address.City);
            Assert.AreEqual(aCountry, aPerson.Address.Country);
            Assert.AreEqual(aPostalCode, aPerson.Address.PostalCode);
            Assert.AreEqual(aTlf, aPerson.Tlf);
            Assert.AreEqual(aMobile, aPerson.Mobile);
            Assert.AreEqual(anEMail, aPerson.EMail);
        }

        [TestMethod]
        public void TestClearPerson()
        {
            string aFirstName = "FirstName";
            string aSecondName = "SeconName";            
            string aStreet = "Street";
            string aNumber = "Number";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "PostalCode";
            string aTlf = "TLF";
            string aMobile = "Mobile";
            string anEMail = "eMail";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Person aPerson = new Person(aFirstName,aSecondName,anAddress,aTlf,aMobile,anEMail);            

            Assert.AreEqual(aFirstName, aPerson.FirstName);
            Assert.AreEqual(aSecondName, aPerson.SecondName);
            Assert.AreEqual(aStreet, aPerson.Address.Street);
            Assert.AreEqual(aNumber, aPerson.Address.Number);
            Assert.AreEqual(aCity, aPerson.Address.City);
            Assert.AreEqual(aCountry, aPerson.Address.Country);
            Assert.AreEqual(aPostalCode, aPerson.Address.PostalCode);
            Assert.AreEqual(aTlf, aPerson.Tlf);
            Assert.AreEqual(aMobile, aPerson.Mobile);
            Assert.AreEqual(anEMail, aPerson.EMail);

            aPerson.ClearPerson();

            Assert.AreEqual(null, aPerson.FirstName);
            Assert.AreEqual(null, aPerson.SecondName);
            Assert.AreEqual(null, aPerson.Address);
            Assert.AreEqual(null, aPerson.Tlf);
            Assert.AreEqual(null, aPerson.Mobile);
            Assert.AreEqual(null, aPerson.EMail);
        }
    }
}
