using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class RaceTypeTests
    {
        [TestMethod]
        public void TestRaceTypeConstructorWithoutData()
        {
            Int32 anID=0;
            string aName=null;
            int points=0;
            string aMemo = null;
            Int32 aSportID = 0;

            RaceType aRaceType = new RaceType();

            Assert.AreEqual(anID, aRaceType.RaceTypeID);
            Assert.AreEqual(aName, aRaceType.Name);
            Assert.AreEqual(points, aRaceType.Points);
            Assert.AreEqual(aMemo, aRaceType.Memo);
            Assert.AreEqual(aSportID, aRaceType.SportID);
        }

        [TestMethod]
        public void TestRaceTypeConstructorWithData()
        {
            Int32 anID = 10;
            string aName = "Super Sprint";
            int points = 20;
            string aMemo = "Triathlón Super Sprint (350/10/2,5)";
            int aSportID = 1;

            RaceType aRaceType = new RaceType(anID,aName,points,aMemo,aSportID);

            Assert.AreEqual(anID, aRaceType.RaceTypeID);
            Assert.AreEqual(aName, aRaceType.Name);
            Assert.AreEqual(points, aRaceType.Points);
            Assert.AreEqual(aMemo, aRaceType.Memo);
            Assert.AreEqual(aSportID, aRaceType.SportID);
        }

        [TestMethod]
        public void TestSetRaceType()
        {
            Int32 anID = 10;
            string aName = "Super Sprint";
            int points = 20;
            string aMemo = "Triathlón Super Sprint (350/10/2,5)";
            int aSportID = 1;

            RaceType aRaceType = new RaceType();
            aRaceType.SetRaceType(anID, aName, points, aMemo, aSportID);

            Assert.AreEqual(anID, aRaceType.RaceTypeID);
            Assert.AreEqual(aName, aRaceType.Name);
            Assert.AreEqual(points, aRaceType.Points);
            Assert.AreEqual(aMemo, aRaceType.Memo);
            Assert.AreEqual(aSportID, aRaceType.SportID);
        }

        [TestMethod]
        public void TestClearRaceType()
        {
            Int32 anID = 10;
            string aName = "Super Sprint";
            int points = 20;
            string aMemo = "Triathlón Super Sprint (350/10/2,5)";
            int aSportID = 1;

            RaceType aRaceType = new RaceType(anID, aName, points, aMemo,aSportID);
            aRaceType.ClearRaceType();

            Assert.AreEqual(0, aRaceType.RaceTypeID);
            Assert.AreEqual(null, aRaceType.Name);
            Assert.AreEqual(0, aRaceType.Points);
            Assert.AreEqual(null, aRaceType.Memo);
            Assert.AreEqual(0, aRaceType.SportID);
        }

        [TestMethod]
        public void TestClearRaceTypeOldRaceTypePresent()
        {
            Int32 anID = 10;
            string aName = "Super Sprint";
            int points = 20;
            string aMemo = "Triathlón Super Sprint (350/10/2,5)";
            int aSportID = 1;

            RaceType aRaceType = new RaceType(anID, aName, points, aMemo, aSportID);
            RaceType oldRaceType = new RaceType();

            Assert.AreEqual(anID, aRaceType.RaceTypeID);
            Assert.AreEqual(aName, aRaceType.Name);
            Assert.AreEqual(points, aRaceType.Points);
            Assert.AreEqual(aMemo, aRaceType.Memo);
            Assert.AreEqual(aSportID, aRaceType.SportID);

            Assert.AreEqual(0, oldRaceType.RaceTypeID);
            Assert.AreEqual(null, oldRaceType.Name);
            Assert.AreEqual(0, oldRaceType.Points);
            Assert.AreEqual(null, oldRaceType.Memo);
            Assert.AreEqual(0, oldRaceType.SportID);

            oldRaceType.CopyRaceType(aRaceType);

            Assert.AreEqual(anID, aRaceType.RaceTypeID);
            Assert.AreEqual(aName, aRaceType.Name);
            Assert.AreEqual(points, aRaceType.Points);
            Assert.AreEqual(aMemo, aRaceType.Memo);
            Assert.AreEqual(aSportID, aRaceType.SportID);

            Assert.AreEqual(anID, oldRaceType.RaceTypeID);
            Assert.AreEqual(aName, oldRaceType.Name);
            Assert.AreEqual(points, oldRaceType.Points);
            Assert.AreEqual(aMemo, oldRaceType.Memo);
            Assert.AreEqual(aSportID, oldRaceType.SportID);

            aRaceType.ClearRaceType();

            Assert.AreEqual(0, aRaceType.RaceTypeID);
            Assert.AreEqual(null, aRaceType.Name);
            Assert.AreEqual(0, aRaceType.Points);
            Assert.AreEqual(null, aRaceType.Memo);
            Assert.AreEqual(0, aRaceType.SportID);

            Assert.AreEqual(anID, oldRaceType.RaceTypeID);
            Assert.AreEqual(aName, oldRaceType.Name);
            Assert.AreEqual(points, oldRaceType.Points);
            Assert.AreEqual(aMemo, oldRaceType.Memo);
            Assert.AreEqual(aSportID, oldRaceType.SportID);
        }
    }
}
