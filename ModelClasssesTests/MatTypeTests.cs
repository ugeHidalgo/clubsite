using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubSite.Model;

namespace ModelClasssesTests
{
    [TestClass]
    public class MatTypeTests
    {
        [TestMethod]
        public void TestMatTypeConstructorWithoutData()
        {
            Int32 anID = 0;
            string aName = null;
            string aMemo = null;

            MaterialType aMatType = new MaterialType();

            Assert.AreEqual(anID, aMatType.MatTypeID);
            Assert.AreEqual(aName, aMatType.Name);
            Assert.AreEqual(aMemo, aMatType.Memo);
        }

        [TestMethod]
        public void TestMatTypeConstructorWithData()
        {
            Int32 anID = 7;
            string aName = "Una familia de material";
            string aMemo = "Esto es un ejemplo de una familia de material.";

            MaterialType aMatType = new MaterialType(anID,aName,aMemo);

            Assert.AreEqual(anID, aMatType.MatTypeID);
            Assert.AreEqual(aName, aMatType.Name);
            Assert.AreEqual(aMemo, aMatType.Memo);
        }

        [TestMethod]
        public void SetMatType()
        {
            Int32 anID = 7;
            string aName = "Una familia de material";
            string aMemo = "Esto es un ejemplo de una familia de material.";

            MaterialType aMatType = new MaterialType();
            aMatType.SetMatType (anID, aName, aMemo);

            Assert.AreEqual(anID, aMatType.MatTypeID);
            Assert.AreEqual(aName, aMatType.Name);
            Assert.AreEqual(aMemo, aMatType.Memo);
        }

        [TestMethod]
        public void ClearMatType()
        {
            Int32 anID = 7;
            string aName = "Una familia de material";
            string aMemo = "Esto es un ejemplo de una familia de material.";

            MaterialType aMatType = new MaterialType(anID, aName, aMemo);

            Assert.AreEqual(anID, aMatType.MatTypeID);
            Assert.AreEqual(aName, aMatType.Name);
            Assert.AreEqual(aMemo, aMatType.Memo);

            aMatType.ClearMatType();
            MaterialType aMatTypeEmpty = new MaterialType();

            Assert.AreEqual(aMatTypeEmpty.MatTypeID, aMatType.MatTypeID);
            Assert.AreEqual(aMatTypeEmpty.Name, aMatType.Name);
            Assert.AreEqual(aMatTypeEmpty.Memo, aMatType.Memo);
        }

        [TestMethod]
        public void CopyMatType()
        {
            Int32 anID1 = 1;
            string aName1 = "Familia de material uno";
            string aMemo1 = "Esto es un ejemplo de la familia de material 1.";
            Int32 anID2 = 0;
            string aName2 = null;
            string aMemo2 = null;

            MaterialType aMatType1 = new MaterialType(anID1, aName1, aMemo1);
            MaterialType aMatType2 = new MaterialType();

            Assert.AreEqual(anID1, aMatType1.MatTypeID);
            Assert.AreEqual(aName1, aMatType1.Name);
            Assert.AreEqual(aMemo1, aMatType1.Memo);
            Assert.AreEqual(anID2, aMatType2.MatTypeID);
            Assert.AreEqual(aName2, aMatType2.Name);
            Assert.AreEqual(aMemo2, aMatType2.Memo);

            aMatType2.CopyMatType(aMatType1);

            Assert.AreEqual(anID1, aMatType2.MatTypeID);
            Assert.AreEqual(aName1, aMatType2.Name);
            Assert.AreEqual(aMemo1, aMatType2.Memo);
        }

    }
}
