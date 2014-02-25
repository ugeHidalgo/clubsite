using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class Race
    {
        //Properties
        #region
        public Int32 Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime RaceDate { get; set; }

        public Int32 RaceTypeId { get; set; }

        public Address Address { get; set; }

        public string Memo { get; set; }

        public virtual RaceType RaceType { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        #endregion
    }
}