using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DidactischeLeermiddelen.Models.domain;
using System.Data.Entity.ModelConfiguration;

namespace DidactischeLeermiddelen.Models.DAL.Mapper
{
    public class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
           ToTable("User");
           HasKey(t => t.UserId);
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).IsRequired().HasMaxLength(100);
            //Property(t => t.Password).IsRequired().HasMaxLength(100);
            Property(t => t.Email).IsRequired().HasMaxLength(100);

           //relationships 

            HasMany(t => t.Wishlist).WithMany(t => t.wishlistusers).Map(t =>
            {
                t.MapLeftKey("MaterialId");
                t.MapRightKey("UserId");
                t.ToTable("wishlist");
            });

            HasMany(t => t.Reservations).WithRequired(t => t.User).WillCascadeOnDelete(false);
        }

    }
}