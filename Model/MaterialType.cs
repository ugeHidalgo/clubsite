using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class MaterialType
    {
         //Properties
        #region
        public Int32 MatTypeID {get; set;}

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        #endregion


        //Constructors
        #region
        public MaterialType()
        {
        }

        public MaterialType(Int32 anID, string aName, string aMemo)
        {
            this.MatTypeID = anID;
            this.Name = aName;
            this.Memo = aMemo;
        }
        #endregion

        //Methods
        #region

        public void SetMatType(int anID, string aName, string aMemo)
        {
            this.MatTypeID = anID;
            this.Name = aName;
            this.Memo = aMemo;
        }

        public void ClearMatType()
        {
            this.MatTypeID = 0;
            this.Name = null;
            this.Memo = null; 
        }

        public void CopyMatType(MaterialType aMatType1)
        {
            this.MatTypeID = aMatType1.MatTypeID;
            this.Name = aMatType1.Name;
            this.Memo = aMatType1.Memo;
        }

        #endregion


    }
}