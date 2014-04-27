using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void TestMemberConstructorWithoutData()
        {
            string aUserName = null;
            string aDNI = null;
            bool aState = false;
            bool federated = false;
            bool visible = false;
            DateTime aRegDate = DateTime.Now;
            DateTime? aBirthdate = null;
            string aMemo = null;
            string anImageURL = null;
            string aNImageURL = null;
            string aBlogURL = null;
            string aFirstName = null;
            string aSecondName = null;
            string aTlf = null;
            string aMobile = null;
            string anEMail = null;

            Member aMember = new Member();

            Assert.AreEqual(aUserName, aMember.UserName);
            Assert.AreEqual(aDNI, aMember.DNI);
            Assert.AreEqual(aState, aMember.State);
            Assert.AreEqual(federated, aMember.Federated);
            Assert.AreEqual(visible, aMember.Visible);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMember.RegDate.ToShortDateString());
            Assert.AreEqual(aBirthdate, aMember.BirthDate);
            Assert.AreEqual(aMemo, aMember.Memo);
            Assert.AreEqual(anImageURL, aMember.ImageURL);
            Assert.AreEqual(aNImageURL, aMember.NImageURL);
            Assert.AreEqual(aBlogURL, aMember.BlogURL);
            Assert.AreEqual(aFirstName, aMember.FirstName);
            Assert.AreEqual(aSecondName, aMember.SecondName);
            Assert.AreEqual(null, aMember.Address);
            Assert.AreEqual(aTlf, aMember.Tlf);
            Assert.AreEqual(aMobile, aMember.Mobile);
            Assert.AreEqual(anEMail, aMember.EMail);
        }

        [TestMethod]
        public void TestMemberConstructorWithData()
        {
            string aUserName = "An user name";
            string aDNI = "DNI Number";
            bool aState = false;
            bool federated = false;
            bool visible = false;
            DateTime aRegDate = DateTime.Now;
            DateTime? aBirthdate = Convert.ToDateTime("12/12/2012");
            string aMemo = "A Memo";
            string anImageURL = "Image URL";
            string aNImageURL = "Image URL";
            string aBlogURL = "A Blog URL";
            string aFirstName = "First name";
            string aSecondName = "Second name";
            string aTlf = "tlf Numbre";
            string aMobile = "Mobile number";
            string anEMail = "Email";
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            string aClubNumber = "14";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Member aMember = new Member(aUserName, aClubNumber, aFirstName, aSecondName, aDNI, anAddress, aTlf, aMobile, anEMail, 
                aState, federated, visible, aBirthdate, aMemo, anImageURL, aNImageURL, aBlogURL);

            Assert.AreEqual(aUserName, aMember.UserName);
            Assert.AreEqual(aDNI, aMember.DNI);
            Assert.AreEqual(aState, aMember.State);
            Assert.AreEqual(federated, aMember.Federated);
            Assert.AreEqual(visible, aMember.Visible);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMember.RegDate.ToShortDateString());
            Assert.AreEqual(aBirthdate, aMember.BirthDate);
            Assert.AreEqual(aMemo, aMember.Memo);
            Assert.AreEqual(anImageURL, aMember.ImageURL);
            Assert.AreEqual(aNImageURL, aMember.NImageURL);
            Assert.AreEqual(aBlogURL, aMember.BlogURL);
            Assert.AreEqual(aFirstName, aMember.FirstName);
            Assert.AreEqual(aSecondName, aMember.SecondName);
            Assert.AreEqual(aStreet, aMember.Address.Street);
            Assert.AreEqual(aNumber, aMember.Address.Number);
            Assert.AreEqual(aCity, aMember.Address.City);
            Assert.AreEqual(aCountry, aMember.Address.Country);
            Assert.AreEqual(aPostalCode, aMember.Address.PostalCode);
            Assert.AreEqual(aTlf, aMember.Tlf);
            Assert.AreEqual(aMobile, aMember.Mobile);
            Assert.AreEqual(anEMail, aMember.EMail);
            Assert.AreEqual(aClubNumber, aMember.Number);
        }

        [TestMethod]
        public void TestSetMember()
        {
            string aUserName = "An user name";
            string aDNI = "DNI Number";
            bool aState = false;
            bool federated = false;
            bool visible = false;
            DateTime aRegDate = DateTime.Now;
            DateTime? aBirthdate = Convert.ToDateTime("12/12/2012");
            string aMemo = "A Memo";
            string anImageURL = "Image URL";
            string aNImageURL = "Image URL";
            string aBlogURL = "A Blog URL";
            string aFirstName = "First name";
            string aSecondName = "Second name";
            string aTlf = "tlf Numbre";
            string aMobile = "Mobile number";
            string anEMail = "Email";
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            string aClubNumber = "14";

            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Member aMember = new Member();
            aMember.SetMember(aUserName, aClubNumber, aFirstName, aSecondName, aDNI, anAddress, aTlf, aMobile, anEMail, 
                aState, federated, visible, aBirthdate, aMemo, anImageURL, aNImageURL, aBlogURL);

            Assert.AreEqual(aUserName, aMember.UserName);
            Assert.AreEqual(aDNI, aMember.DNI);
            Assert.AreEqual(aState, aMember.State);
            Assert.AreEqual(federated, aMember.Federated);
            Assert.AreEqual(visible, aMember.Visible);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMember.RegDate.ToShortDateString());
            Assert.AreEqual(aBirthdate, aMember.BirthDate);
            Assert.AreEqual(aMemo, aMember.Memo);
            Assert.AreEqual(anImageURL, aMember.ImageURL);
            Assert.AreEqual(aNImageURL, aMember.NImageURL);
            Assert.AreEqual(aBlogURL, aMember.BlogURL);
            Assert.AreEqual(aFirstName, aMember.FirstName);
            Assert.AreEqual(aSecondName, aMember.SecondName);
            Assert.AreEqual(aStreet, aMember.Address.Street);
            Assert.AreEqual(aNumber, aMember.Address.Number);
            Assert.AreEqual(aCity, aMember.Address.City);
            Assert.AreEqual(aCountry, aMember.Address.Country);
            Assert.AreEqual(aPostalCode, aMember.Address.PostalCode);
            Assert.AreEqual(aTlf, aMember.Tlf);
            Assert.AreEqual(aMobile, aMember.Mobile);
            Assert.AreEqual(anEMail, aMember.EMail);
            Assert.AreEqual(aClubNumber, aMember.Number);
        }

        [TestMethod]
        public void TestClearMember()
        {
            string aUserName = "An user name";
            string aDNI = "DNI Number";
            bool aState = false;
            bool federated = false;
            bool visible = false;
            DateTime aRegDate = DateTime.Now;
            DateTime? aBirthdate = Convert.ToDateTime("12/12/2012");
            string aMemo = "A Memo";
            string anImageURL = "Image URL";
            string aNImageURL = "Image URL";
            string aBlogURL = "A Blog URL";
            string aFirstName = "First name";
            string aSecondName = "Second name";
            string aTlf = "tlf Numbre";
            string aMobile = "Mobile number";
            string anEMail = "Email";
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            string aClubNumber = "14";

            Address anAddress = new Address(aStreet,  aNumber, aCity, aCountry, aPostalCode);
            Member aMember = new Member(aUserName, aClubNumber, aFirstName, aSecondName, aDNI, anAddress, aTlf, aMobile, anEMail,
                aState, federated, visible, aBirthdate, aMemo, anImageURL, aNImageURL, aBlogURL);

            Assert.AreEqual(aUserName, aMember.UserName);
            Assert.AreEqual(aDNI, aMember.DNI);
            Assert.AreEqual(aState, aMember.State);
            Assert.AreEqual(federated, aMember.Federated);
            Assert.AreEqual(visible, aMember.Visible);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMember.RegDate.ToShortDateString());
            Assert.AreEqual(aBirthdate, aMember.BirthDate);
            Assert.AreEqual(aMemo, aMember.Memo);
            Assert.AreEqual(anImageURL, aMember.ImageURL);
            Assert.AreEqual(aNImageURL, aMember.NImageURL);
            Assert.AreEqual(aBlogURL, aMember.BlogURL);
            Assert.AreEqual(aFirstName, aMember.FirstName);
            Assert.AreEqual(aSecondName, aMember.SecondName);
            Assert.AreEqual(aStreet, aMember.Address.Street);
            Assert.AreEqual(aNumber, aMember.Address.Number);
            Assert.AreEqual(aCity, aMember.Address.City);
            Assert.AreEqual(aCountry, aMember.Address.Country);
            Assert.AreEqual(aPostalCode, aMember.Address.PostalCode);
            Assert.AreEqual(aTlf, aMember.Tlf);
            Assert.AreEqual(aMobile, aMember.Mobile);
            Assert.AreEqual(anEMail, aMember.EMail);
            Assert.AreEqual(aClubNumber, aMember.Number);

            aMember.ClearMember();

            Assert.AreEqual(null, aMember.UserName);
            Assert.AreEqual(null, aMember.DNI);
            Assert.AreEqual(false, aMember.State);
            Assert.AreEqual(false, aMember.Federated);
            Assert.AreEqual(false, aMember.Visible);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMember.RegDate.ToShortDateString());
            Assert.AreEqual(null, aMember.BirthDate);
            Assert.AreEqual(null, aMember.Memo);
            Assert.AreEqual(null, aMember.ImageURL);
            Assert.AreEqual(null, aMember.NImageURL);
            Assert.AreEqual(null, aMember.BlogURL);
            Assert.AreEqual(null, aMember.FirstName);
            Assert.AreEqual(null, aMember.SecondName);
            Assert.AreEqual(null, aMember.Address);
            Assert.AreEqual(null, aMember.Tlf);
            Assert.AreEqual(null, aMember.Mobile);
            Assert.AreEqual(null, aMember.EMail);
            Assert.AreEqual(null, aMember.Number);
        }
    }
}
