using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public abstract class User
    {

        public virtual ICollection<Material> Wishlist { get;  set; }
        public User()
        {
            Wishlist = new List<Material>();
            Reservations = new List<ReservedMaterial>();
        }

        public string UserName
        {		
           get; set;
        }

        public String Faculty
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Picture
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

     

        public virtual ICollection<ReservedMaterial> Reservations
        {
            get; set;
        }

        public int UserId { get; internal set; }

        public void AddToWishList(Material material)
        {
            if(!Wishlist.Contains(material))
            {
                Wishlist.Add(material);
            }
            
        }

        public void RemoveFromWishList(Material material)
        {
            if(Wishlist.Contains(material))
            {
                Wishlist.Remove(material);
            }

        }

        public abstract void ReserveMaterial(Material material, int amount, DateTime start, DateTime creation);

        public void SetWishlistBoolean(Material m) {

            m.IsInWishlist = true;
        }
        public void RemoveFromReservations(ReservedMaterial m)
        {
            if (Reservations.Contains(m))
            {
                Reservations.Remove(m);
            }


        }



    }
    }
