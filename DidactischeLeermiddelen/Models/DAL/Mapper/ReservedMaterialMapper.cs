using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class ReservedMaterialMapper: EntityTypeConfiguration<ReservedMaterial>
    {
    
        public ReservedMaterialMapper(){
            ToTable("Reservation");
            this.HasKey(t => t.ReservedMaterialId);

            Property(t => t.AmountReserved).IsRequired();
            Property(t => t.StartDate).IsRequired();

            //HasRequired(t => t.User).WithMany().Map(m => m.MapKey("ReservedMaterialId")).WillCascadeOnDelete(false);
            //HasRequired(t => t.Material).WithMany().Map(m => m.MapKey("ReservedMaterialId")).WillCascadeOnDelete(false);
     

    }

    }
}