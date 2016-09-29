using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Material
    {
        #region Fields
        private int broken;
        private string name;
        #endregion

        #region Properties
        public int MaterialId { get; set; }
        [Display(Name = "Foto")]
        public string ImagePath { get; set; }
        [Display(Name = "Naam")]
        public string Name
        {
            get{ return name;}
            set
            {
                if (value == null) throw new ArgumentException();
                name = value;
            }
        }
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
        [Display(Name = "Doelgroepen")]
        public virtual ICollection<TargetAudience> TargetAudiences { get; set; }
        [Display(Name = "Deelgebieden")]
        public virtual ICollection<Curricular> Curriculars { get; set; }
        public virtual ICollection<User> wishlistusers { get; set; }
        public virtual Company Company { get; set; }
        [Display(Name = "Artikel nummer")]
        public string ItemNumber { get; set; }
        [Display(Name = "Prijs")]
        public double Price { get; set; }
        [Display(Name = "Totaal aantal")]
        public int TotalAmount { get; set; }
        [Display(Name = "Aantal kapot")]
        public int Broken
        {
            get { return broken; }
            set
            {
                if (value > TotalAmount)
                    throw new ArgumentException("Het beschikbare aantal kan niet grooter zijn dan het aantal.");
                broken = value;
            }
        }
        public Boolean Lendable { get; set; }
        [Display(Name = "Locatie")]
        public string Location
        {
            get; set;
        }

        public virtual ICollection<ReservedMaterial> Reservations { get; set; }

        public void AddToReservations(ReservedMaterial reservedMaterial)
        {
            Reservations.Add(reservedMaterial);
        }

        public void RemoveFromReservations(ReservedMaterial reservedMaterial)
        {
            Reservations.Remove(reservedMaterial);
        }
        public Boolean IsInWishlist { get; set; }
            
        
        public int GetAmountAvailable(DateTime dag)
        {
            int aantalgereserveerd = 0;
            
            foreach(ReservedMaterial r in Reservations)
            {
                if(r.StartDate.CompareTo(dag)<=0 && r.EndDate.CompareTo(dag)>0)
                aantalgereserveerd = aantalgereserveerd + r.AmountReserved;
           }
            return TotalAmount - Broken - aantalgereserveerd;

        }

    }
   }
 
    
        #endregion
    
