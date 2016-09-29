using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class MaterialMapper : EntityTypeConfiguration<Material>
    {
        public MaterialMapper()
        {
            this.ToTable("Material");

            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Property(t => t.Location).IsRequired().HasMaxLength(100);
            //HasRequired(t => t.Company).WithMany().Map(m => m.MapKey("CompanyId")).WillCascadeOnDelete(false);
            //HasMany(t => t.Curriculars).WithRequired().Map(m => m.MapKey("CurricalarId")).WillCascadeOnDelete(false);
            //HasMany(t => t.TargetAudiences).WithRequired().Map(m => m.MapKey("TargetAudienceId")).WillCascadeOnDelete(false);


            HasMany(t => t.wishlistusers).WithRequired().Map(m => m.MapKey("UserId")).WillCascadeOnDelete(false);
            HasMany(t => t.Reservations).WithRequired().Map(m => m.MapKey("ReservedMaterialId")).WillCascadeOnDelete(false);
            this.HasKey(t => t.MaterialId);
        }
    }
}