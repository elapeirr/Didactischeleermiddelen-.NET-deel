using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class CurricularMapper : EntityTypeConfiguration<Curricular>
    {
        public CurricularMapper()
        {
            ToTable("Curricular");

            HasKey(t => t.CurricularId);
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            HasMany(t => t.Materials).WithMany(t => t.Curriculars).Map(t => { 
              t.MapLeftKey("MaterialId");
              t.MapRightKey("CurricularId");
              t.ToTable("MaterialCurricular");
            });
        }
    }
}