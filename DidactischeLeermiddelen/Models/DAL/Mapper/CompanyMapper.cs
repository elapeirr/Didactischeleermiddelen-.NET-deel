using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class CompanyMapper : EntityTypeConfiguration<Company>
    {
        public CompanyMapper()
        {
   ToTable("Company");

           // this.HasKey(t => t.CompanyId);
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            HasMany(t => t.Materials).WithRequired(t => t.Company).Map(m => m.MapKey("CompanyId")).WillCascadeOnDelete(false);
        }
    }
}