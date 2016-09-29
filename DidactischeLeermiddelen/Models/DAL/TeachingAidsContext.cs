using DidactischeLeermiddelen.Models.domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class TeachingAidsContext : IdentityDbContext<ApplicationUser>
    {
        public TeachingAidsContext() : base("TeachingAids")
        {
            Database.SetInitializer<TeachingAidsContext>(new TeachingAidsInitializer());
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<TargetAudience> TargetAudiences { get; set; }
        public DbSet<Curricular> Curriculars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReservedMaterial> Reservations { get; set; }
        public static TeachingAidsContext Create() {
            return DependencyResolver.Current.GetService<TeachingAidsContext>(); }
    }
}