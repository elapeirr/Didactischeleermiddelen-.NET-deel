using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class TargetAudienceMapper : EntityTypeConfiguration<TargetAudience>
    {
        public TargetAudienceMapper()
        {
            ToTable("TargetAudience");

            HasKey(t => t.TargetAudienceId);

            HasMany(t => t.Materials).WithMany(t => t.TargetAudiences).Map(t => {
                t.MapLeftKey("MaterialId");
                t.MapRightKey("TargetAudienceId");
                t.ToTable("MaterialTargetAudience");
            });
        }
    }
}