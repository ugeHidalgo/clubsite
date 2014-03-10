using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class MaterialTests
    {
        [TestMethod]
        public void TestMatConstructorWithoutData()
        {
            Int32 aMatID = 0;
            string aMatName = null;
            Int32 aMatTypeId = 0;
            bool active = false;
            decimal aCost = 0;
            decimal aPrice = 0;
            DateTime aRegDate = DateTime.Now;
            string aMemo = null;

            Material aMat = new Material();

            Assert.AreEqual(aMatID, aMat.MatID);
            Assert.AreEqual(aMatName, aMat.MatName);
            Assert.AreEqual(aMatTypeId, aMat.MatTypeId);
            Assert.AreEqual(active, aMat.Active);
            Assert.AreEqual(aCost, aMat.Cost);
            Assert.AreEqual(aPrice, aMat.Price);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMemo, aMat.Memo);
        }

        [TestMethod]
        public void TestMatConstructorWithData()
        {
            Int32 aMatID = 1;
            string aMatName = "Material uno";
            Int32 aMatTypeId = 1;
            bool active = true;
            decimal aCost = (decimal)32.3;
            decimal aPrice = (decimal)39.5;
            DateTime aRegDate = DateTime.Now;
            string aMemo = "Memo del Material uno";

            Material aMat = new Material(aMatID, aMatName, aMatTypeId, active, aCost, aPrice, aMemo);

            Assert.AreEqual(aMatID, aMat.MatID);
            Assert.AreEqual(aMatName, aMat.MatName);
            Assert.AreEqual(aMatTypeId, aMat.MatTypeId);
            Assert.AreEqual(active, aMat.Active);
            Assert.AreEqual(aCost, aMat.Cost);
            Assert.AreEqual(aPrice, aMat.Price);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMemo, aMat.Memo);
        }

        [TestMethod]
        public void SetMat()
        {
            Int32 aMatID = 1;
            string aMatName = "Material uno";
            Int32 aMatTypeId = 1;
            bool active = true;
            decimal aCost = (decimal)32.3;
            decimal aPrice = (decimal)39.5;
            DateTime aRegDate = DateTime.Now;
            string aMemo = "Memo del Material uno";

            Material aMat = new Material();
            aMat.SetMaterial(aMatID, aMatName, aMatTypeId, active, aCost, aPrice, aMemo);

            Assert.AreEqual(aMatID, aMat.MatID);
            Assert.AreEqual(aMatName, aMat.MatName);
            Assert.AreEqual(aMatTypeId, aMat.MatTypeId);
            Assert.AreEqual(active, aMat.Active);
            Assert.AreEqual(aCost, aMat.Cost);
            Assert.AreEqual(aPrice, aMat.Price);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMemo, aMat.Memo);
        }

        [TestMethod]
        public void ClearMat()
        {
            Int32 aMatID = 1;
            string aMatName = "Material uno";
            Int32 aMatTypeId = 1;
            bool active = true;
            decimal aCost = (decimal)32.3;
            decimal aPrice = (decimal)39.5;
            DateTime aRegDate = DateTime.Now;
            string aMemo = "Memo del Material uno";

            Material aMat = new Material(aMatID, aMatName, aMatTypeId, active, aCost, aPrice, aMemo);
            Material aMatEmpty = new Material();

            Assert.AreEqual(aMatID, aMat.MatID);
            Assert.AreEqual(aMatName, aMat.MatName);
            Assert.AreEqual(aMatTypeId, aMat.MatTypeId);
            Assert.AreEqual(active, aMat.Active);
            Assert.AreEqual(aCost, aMat.Cost);
            Assert.AreEqual(aPrice, aMat.Price);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMemo, aMat.Memo);

            aMat.ClearMaterial();

            Assert.AreEqual(aMatEmpty.MatID, aMat.MatID);
            Assert.AreEqual(aMatEmpty.MatName, aMat.MatName);
            Assert.AreEqual(aMatEmpty.MatTypeId, aMat.MatTypeId);
            Assert.AreEqual(aMatEmpty.Active, aMat.Active);
            Assert.AreEqual(aMatEmpty.Cost, aMat.Cost);
            Assert.AreEqual(aMatEmpty.Price, aMat.Price);
            Assert.AreEqual(aMatEmpty.RegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMatEmpty.Memo, aMat.Memo);
        }

        [TestMethod]
        public void CopyMaterial()
        {
            Int32 aMatID = 1;
            string aMatName = "Material uno";
            Int32 aMatTypeId = 1;
            bool active = true;
            decimal aCost = (decimal)32.3;
            decimal aPrice = (decimal)39.5;
            DateTime aRegDate = DateTime.Now;
            string aMemo = "Memo del Material uno";

            Material aMat = new Material(aMatID, aMatName, aMatTypeId, active, aCost, aPrice, aMemo);
            Material aMatEmpty = new Material();

            Assert.AreEqual(aMatID, aMat.MatID);
            Assert.AreEqual(aMatName, aMat.MatName);
            Assert.AreEqual(aMatTypeId, aMat.MatTypeId);
            Assert.AreEqual(active, aMat.Active);
            Assert.AreEqual(aCost, aMat.Cost);
            Assert.AreEqual(aPrice, aMat.Price);
            Assert.AreEqual(aRegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMemo, aMat.Memo);

            aMatEmpty.CopyMaterial(aMat);

            Assert.AreEqual(aMatEmpty.MatID, aMat.MatID);
            Assert.AreEqual(aMatEmpty.MatName, aMat.MatName);
            Assert.AreEqual(aMatEmpty.MatTypeId, aMat.MatTypeId);
            Assert.AreEqual(aMatEmpty.Active, aMat.Active);
            Assert.AreEqual(aMatEmpty.Cost, aMat.Cost);
            Assert.AreEqual(aMatEmpty.Price, aMat.Price);
            Assert.AreEqual(aMatEmpty.RegDate.ToShortDateString(), aMat.RegDate.ToShortDateString());
            Assert.AreEqual(aMatEmpty.Memo, aMat.Memo);
        }
    }
}
