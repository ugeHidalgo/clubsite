using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;
using System.Collections.Generic;

namespace ModelClasssesTests
{
    [TestClass]
    public class RaceTests
    {
        [TestMethod]
        public void TestRaceConstructorWithoutData()
        {
            Int32 anID = 0;
            string aName = null;
            DateTime aRaceDate = DateTime.Now;
            Address anAddress = null;
            Int32 aRaceTypeId = 0;
            string aMemo = null;

            Race aRace = new Race();

            Assert.AreEqual(anID, aRace.Id);
            Assert.AreEqual(aName, aRace.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(anAddress, aRace.Address);
            Assert.AreEqual(aRaceTypeId, aRace.RaceTypeId);
            Assert.AreEqual(aMemo, aRace.Memo);
        }

        [TestMethod]
        public void TestRaceConstructorWithData()
        {
            Int32 anID = 10;
            string aName = "Ejemplo de carrera";
            DateTime aRaceDate = DateTime.Now;
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Int32 aRaceTypeId = 20;
            string aMemo = "memo";

            Race aRace = new Race(anID,aName, aRaceDate, anAddress, aRaceTypeId,aMemo);

            Assert.AreEqual(anID, aRace.Id);
            Assert.AreEqual(aName, aRace.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(aStreet, aRace.Address.Street);
            Assert.AreEqual(aNumber, aRace.Address.Number);
            Assert.AreEqual(aCity, aRace.Address.City);
            Assert.AreEqual(aCountry, aRace.Address.Country);
            Assert.AreEqual(aPostalCode, aRace.Address.PostalCode);
            Assert.AreEqual(aRaceTypeId, aRace.RaceTypeId);
            Assert.AreEqual(aMemo, aRace.Memo);
        }

        [TestMethod]
        public void SetRace()
        {
            Int32 anID = 10;
            string aName = "Ejemplo de carrera";
            DateTime aRaceDate = DateTime.Now;
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Int32 aRaceTypeId = 20;
            string aMemo = "memo";

            Race aRace = new Race();
            aRace.SetRace(anID, aName, aRaceDate, anAddress, aRaceTypeId, aMemo);

            Assert.AreEqual(anID, aRace.Id);
            Assert.AreEqual(aName, aRace.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(aStreet, aRace.Address.Street);
            Assert.AreEqual(aNumber, aRace.Address.Number);
            Assert.AreEqual(aCity, aRace.Address.City);
            Assert.AreEqual(aCountry, aRace.Address.Country);
            Assert.AreEqual(aPostalCode, aRace.Address.PostalCode);
            Assert.AreEqual(aRaceTypeId, aRace.RaceTypeId);
            Assert.AreEqual(aMemo, aRace.Memo);
        }

        [TestMethod]
        public void ClearRace()
        {
            Int32 anID = 10;
            string aName = "Ejemplo de carrera";
            DateTime aRaceDate = DateTime.Now;
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Int32 aRaceTypeId = 20;
            string aMemo = "memo";

            Race aRace = new Race(anID, aName, aRaceDate, anAddress, aRaceTypeId, aMemo);
            aRace.ClearRace();

            anID = 0;
            aName = null;
            aRaceDate = DateTime.Now;
            anAddress = null;
            aRaceTypeId = 0;
            aMemo = null;

            Assert.AreEqual(anID, aRace.Id);
            Assert.AreEqual(aName, aRace.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(null, aRace.Address);            
            Assert.AreEqual(aRaceTypeId, aRace.RaceTypeId);
            Assert.AreEqual(aMemo, aRace.Memo);
        }

        [TestMethod]
        public void CopyRace()
        {
            Int32 anID = 10;
            string aName = "Ejemplo de carrera";
            DateTime aRaceDate = DateTime.Now;
            string aStreet = "Street";
            string aNumber = "1a";
            string aCity = "City";
            string aCountry = "Country";
            string aPostalCode = "18007";
            Address anAddress = new Address(aStreet, aNumber, aCity, aCountry, aPostalCode);
            Int32 aRaceTypeId = 20;
            string aMemo = "memo";

            Race aRace = new Race(anID, aName, aRaceDate, anAddress, aRaceTypeId, aMemo);
            Race aRace2 = new Race();

            Assert.AreEqual(anID, aRace.Id);
            Assert.AreEqual(aName, aRace.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(aStreet, aRace.Address.Street);
            Assert.AreEqual(aNumber, aRace.Address.Number);
            Assert.AreEqual(aCity, aRace.Address.City);
            Assert.AreEqual(aCountry, aRace.Address.Country);
            Assert.AreEqual(aPostalCode, aRace.Address.PostalCode);
            Assert.AreEqual(aRaceTypeId, aRace.RaceTypeId);
            Assert.AreEqual(aMemo, aRace.Memo);

            Assert.AreEqual(0, aRace2.Id);
            Assert.AreEqual(null, aRace2.Name);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), aRace2.RaceDate.ToShortDateString());
            Assert.AreEqual(null, aRace2.Address);
            Assert.AreEqual(0, aRace2.RaceTypeId);
            Assert.AreEqual(null, aRace2.Memo);

            aRace2.CopyRace(aRace);
            aRace.ClearRace();

            Assert.AreEqual(anID, aRace2.Id);
            Assert.AreEqual(aName, aRace2.Name);
            Assert.AreEqual(aRaceDate.ToShortDateString(), aRace2.RaceDate.ToShortDateString());
            Assert.AreEqual(aStreet, aRace2.Address.Street);
            Assert.AreEqual(aNumber, aRace2.Address.Number);
            Assert.AreEqual(aCity, aRace2.Address.City);
            Assert.AreEqual(aCountry, aRace2.Address.Country);
            Assert.AreEqual(aPostalCode, aRace2.Address.PostalCode);
            Assert.AreEqual(aRaceTypeId, aRace2.RaceTypeId);
            Assert.AreEqual(aMemo, aRace2.Memo);

            Assert.AreEqual(0, aRace.Id);
            Assert.AreEqual(null, aRace.Name);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), aRace.RaceDate.ToShortDateString());
            Assert.AreEqual(null, aRace.Address);
            Assert.AreEqual(0, aRace.RaceTypeId);
            Assert.AreEqual(null, aRace.Memo);
        }

        [TestMethod]
        public void loadRaceData()
        {
            Address anAdress = new Address();
            var aListOfRaces = new List<Race> {
                new Race { Id=1, Name="Media Maratón de Almería", Address =anAdress, RaceDate=Convert.ToDateTime("12/02/2014 00:00:00"), RaceTypeId=12 },
                new Race { Id=2, Name="Triatlón de Elche Arenales", Address =anAdress, RaceDate=Convert.ToDateTime("20/04/2014 00:00:00"), RaceTypeId=4 },
                new Race { Id=3, Name="Triatlón Cross Tarifa XChallenge", Address =anAdress, RaceDate=Convert.ToDateTime("12/06/2014 00:00:00"), RaceTypeId=3 },
                new Race { Id=4, Name="Ironman Lanzarote", Address =anAdress, RaceDate=Convert.ToDateTime("12/05/2014 00:00:00"), RaceTypeId=5 } };
            Assert.AreEqual(1, aListOfRaces[0].Id);
            Assert.AreEqual("12/02/2014 0:00:00", aListOfRaces[0].RaceDate.ToString());
            Assert.AreEqual(12, aListOfRaces[0].RaceTypeId);
        }

        [TestMethod]
        public void addMembeToRaceMembersList()
        {
            //Create a few Races
            Address anAdress = new Address();
            var aListOfRaces = new List<Race> {
                new Race { Id=1, Name="Media Maratón de Almería", Address =anAdress, RaceDate=Convert.ToDateTime("12/02/2014 00:00:00"), RaceTypeId=12 },
                new Race { Id=2, Name="Triatlón de Elche Arenales", Address =anAdress, RaceDate=Convert.ToDateTime("20/04/2014 00:00:00"), RaceTypeId=4 },
                new Race { Id=3, Name="Triatlón Cross Tarifa XChallenge", Address =anAdress, RaceDate=Convert.ToDateTime("12/06/2014 00:00:00"), RaceTypeId=3 },
                new Race { Id=4, Name="Ironman Lanzarote", Address =anAdress, RaceDate=Convert.ToDateTime("12/05/2014 00:00:00"), RaceTypeId=5 } };


            //Create a few Members
            var aListOfMembers = new List<Member> { 
                new Member { UserName="User1", FirstName="Pepe", SecondName="López", Address=anAdress },
                new Member { UserName="User2", FirstName="Pepe", SecondName="López", Address=anAdress },
                new Member { UserName="User3", FirstName="Pepe", SecondName="López", Address=anAdress },
                new Member { UserName="User4", FirstName="Pepe", SecondName="López", Address=anAdress },
            };
            
            //Add Member to race
            aListOfRaces[0].AddMemberToRace("User1");

            //Verify if aMember is in Members for Race
            Assert.AreEqual(aListOfRaces[0].Members.Contains(aListOfMembers[0]), true);
        }

        [TestMethod]
        public void delMembeFromRaceMembersList()
        {
        }
    }
}
