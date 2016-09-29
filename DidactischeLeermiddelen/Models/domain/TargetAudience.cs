using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public class TargetAudience
    {
        #region Properties
        public int TargetAudienceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public TargetAudience() {

            Materials = new HashSet<Material>();
        }
        #endregion

        public void AddMaterial(Material materiaal) {
            Materials.Add(materiaal);
        }
    }
}