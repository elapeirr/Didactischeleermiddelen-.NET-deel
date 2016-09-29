using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;

namespace DidactischeLeermiddelen.Models.domain
{
    public class ReservedMaterial
    {
        private User user;
        private Material material;
        private int amount;

        public int ReservedMaterialId { get; set; }

        [Display(Name = "Aantal")]
        public int AmountReserved
        {
            get { return amount; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                amount = value;
            }
        }
        [Display(Name = "Start datum")]
        public DateTime StartDate
        {
            get; set;
        }

        public DateTime CreationDate
        {
            get; set;
        }

        public DateTime EndDate { get; set; }

        public virtual User User
        {
            get { return user; }
            set
            {
                //if (value == null) throw new ArgumentException();
                user = value;
            }
        }

        public virtual Material Material
        {
            get { return material; }
            set
            {
                //if (value == null) throw new ArgumentException();
                material = value;
            }
        }

        [Display(Name = "Naam")]
        public String name { get; set; }

        public String useremail { get; set; }

        public string Location { get; set; }
    }
}