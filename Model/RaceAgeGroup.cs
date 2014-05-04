using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSite.Model
{
    public class RaceAgeGroup
    {
        [Key]
        public Int32 Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public Int32 Part { get; set; }

        public Int32 RaceID { get; set; }

        public virtual Race Race { get; set; }        
    }
}