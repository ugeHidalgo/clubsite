using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace ModelClasssesTests
{
    [TestClass]
    public class SportTests
    {
        [TestMethod]
        public void TestSportConstructorWithoutData()
        {
            Int32 anID = 0;
            string aName = null;
            string aMemo = null;

            Sport aSport = new Sport();

            Assert.AreEqual(anID, aSport.SportID);
            Assert.AreEqual(aName, aSport.Name);
            Assert.AreEqual(aMemo, aSport.Memo);
        }


        [TestMethod]
        public void TestSportConstructorWithData()
        {
            Int32 anID = 10;
            string aName = "Triathlon";
            string aMemo = "Esto es un ejemplo de memo";

            Sport aSport = new Sport(anID, aName, aMemo);

            Assert.AreEqual(anID, aSport.SportID);
            Assert.AreEqual(aName, aSport.Name);
            Assert.AreEqual(aMemo, aSport.Memo);
        }

        [TestMethod]
        public void TestSetSport()
        {
            Int32 anID = 10;
            string aName = "Triathlon";
            string aMemo = "Esto es un ejemplo de memo";

            Sport aSport = new Sport();
            aSport.SetSport(anID, aName, aMemo);

            Assert.AreEqual(anID, aSport.SportID);
            Assert.AreEqual(aName, aSport.Name);
            Assert.AreEqual(aMemo, aSport.Memo);
        }

        [TestMethod]
        public void TestClearSport()
        {
            Int32 anID = 10;
            string aName = "Triathlon";
            string aMemo = "Esto es un ejemplo de memo";

            Sport aSport = new Sport(anID, aName, aMemo);
            aSport.ClearSport();

            Assert.AreEqual(0, aSport.SportID);
            Assert.AreEqual(null, aSport.Name);
            Assert.AreEqual(null, aSport.Memo);
        }

        [TestMethod]
        public void TestClearSportOldSportPresent()
        {
            Int32 anID = 10;
            string aName = "Triathlon";
            string aMemo = "Esto es un ejemplo de memo";

            Sport aSport = new Sport(anID, aName, aMemo);
            Sport oldSport = new Sport();

            Assert.AreEqual(anID, aSport.SportID);
            Assert.AreEqual(aName, aSport.Name);
            Assert.AreEqual(aMemo, aSport.Memo);

            Assert.AreEqual(0, oldSport.SportID);
            Assert.AreEqual(null, oldSport.Name);
            Assert.AreEqual(null, oldSport.Memo);

            oldSport.CopySport(aSport);

            Assert.AreEqual(anID, aSport.SportID);
            Assert.AreEqual(aName, aSport.Name);
            Assert.AreEqual(aMemo, aSport.Memo);

            Assert.AreEqual(anID, oldSport.SportID);
            Assert.AreEqual(aName, oldSport.Name);
            Assert.AreEqual(aMemo, oldSport.Memo);

            aSport.ClearSport();

            Assert.AreEqual(0, aSport.SportID);
            Assert.AreEqual(null, aSport.Name);
            Assert.AreEqual(null, aSport.Memo);

            Assert.AreEqual(anID, oldSport.SportID);
            Assert.AreEqual(aName, oldSport.Name);
            Assert.AreEqual(aMemo, oldSport.Memo);
        }
    }
}
