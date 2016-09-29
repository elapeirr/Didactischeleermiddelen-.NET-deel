using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Company
    {
        #region Properties
        public int CompanyId { get; set; }
        [Display(Name = "Firma")]
        public string Name { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        #endregion
       
        
        //Als we werken zoals category van sportstore 
        public virtual List<Material> Materials { get; set; }//

        public Company() {
            Materials = new List<Material>();  //
        }

        public void AddMaterial(Material materiaal) {//
            
                Materials.Add(materiaal);

            
        }

        public Material FindProduct(string naam) {//
            return Materials.Where(m => m.Name == naam).FirstOrDefault();
        }
        
    }
}