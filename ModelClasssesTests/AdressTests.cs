using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class AdressTests
    {       
        [TestMethod]
        public void TestAddresConstructorWithoutData()
        {
            string aStreet = null;
            string aNumber = null;
            string aCity = null;
            string aCountry = null;
            string aPostalCode = null;

            Address anAddress = new Address();

            Assert.AreEqual(aStreet, anAddress.Street);
            Assert.AreEqual(aNumber, anAddress.Number);
            Assert.AreEqual(aCity, anAddress.City);
            Assert.AreEqual(aCountry, anAddress.Country);
            Assert.AreEqual(aPostalCode, anAddress.PostalCode);
        }

        [TestMethod]
        public void TestAddressConstructorWitData()
        {
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);

            Assert.AreEqual(aStreet, anAddress.Street);
            Assert.AreEqual(aNumber, anAddress.Number);
            Assert.AreEqual(aCity, anAddress.City);
            Assert.AreEqual(aCountry, anAddress.Country);
            Assert.AreEqual(aPostalCode, anAddress.PostalCode);
        }

        [TestMethod]
        public void TestSetAddress()
        {
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";

            Address anAddress = new Address();
            anAddress.SetAddress(aStreet, aNumber, aCity, aCountry, aPostalCode);

            Assert.AreEqual(aStreet, anAddress.Street);
            Assert.AreEqual(aNumber, anAddress.Number);
            Assert.AreEqual(aCity, anAddress.City);
            Assert.AreEqual(aCountry, anAddress.Country);
            Assert.AreEqual(aPostalCode, anAddress.PostalCode);
        }

        [TestMethod]
        public void TestClearAddress()
        {
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";

            Address anAddress = new Address();
            anAddress.SetAddress(aStreet, aNumber, aCity, aCountry, aPostalCode);
            anAddress.ClearAddress();

            Assert.AreEqual(null, anAddress.Street);
            Assert.AreEqual(null, anAddress.Number);
            Assert.AreEqual(null, anAddress.City);
            Assert.AreEqual(null, anAddress.Country);
            Assert.AreEqual(null, anAddress.PostalCode);
        }
    }
}
