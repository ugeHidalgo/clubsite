using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class Material
    {
        //Properties
        #region
        public Int32 MatID {get; set;}

        [Required, StringLength(100)]
        public string MatName { get; set; }

        public Int32 MatTypeId { get; set; } 

        public bool Active {get; set;}

        public decimal Cost { get; set; }

        public decimal Price {get; set;}

        public DateTime RegDate {get; set; }

        public string Memo { get; set; }

        public virtual MaterialType MaterialType { get; set; }

        #endregion


        //Constructors
        #region
        public Material()
        {
            this.Active = false;
            this.RegDate = DateTime.Now;
        }

        public Material(Int32 anID, string aName, Int32 aMatTypeId, bool active, decimal aCost, decimal aPrice, string aMemo)
        {
            this.MatID = anID;
            this.MatName = aName;
            this.MatTypeId = aMatTypeId;
            this.Active = active;
            this.Cost = aCost;
            this.Price = aPrice;
            this.RegDate = DateTime.Now;
            this.Memo = aMemo;
        }
        #endregion

        //Methods
        #region

        public void SetMaterial(Int32 anID, string aName, Int32 aMatTypeId, bool active, decimal aCost, decimal aPrice, string aMemo)
        {
            this.MatID = anID;
            this.MatName = aName;
            this.MatTypeId = aMatTypeId;
            this.Active = active;
            this.Cost = aCost;
            this.Price = aPrice;
            this.RegDate = DateTime.Now;
            this.Memo = aMemo; 
        }

        public void ClearMaterial()
        {
            this.MatID = 0;
            this.MatName = null;
            this.MatTypeId = 0;
            this.Active = false;
            this.Cost = 0;
            this.Price = 0;
            this.RegDate = DateTime.Now;
            this.Memo = null;
        }

        public void CopyMaterial(Material aMaterial)
        {
            this.MatID = aMaterial.MatID;
            this.MatName = aMaterial.MatName;
            this.MatTypeId = aMaterial.MatTypeId;
            this.Active = aMaterial.Active;
            this.Cost = aMaterial.Cost;
            this.Price = aMaterial.Price;
            this.RegDate = aMaterial.RegDate;
            this.Memo = aMaterial.Memo;
        }

        #endregion
    }
}