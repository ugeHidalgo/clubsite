using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ClubSite.Model;

namespace ClubSite.Model
{
    public class ClubSiteContext : DbContext
    {        
        public DbSet<Member> Members { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<RaceType> RaceTypes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<RaceAgeGroup> RaceAgeGroups { get; set; }

        public ClubSiteContext()
            : base("ClubSiteConn")
        {
        }
    }
}