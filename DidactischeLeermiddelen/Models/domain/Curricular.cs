using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Curricular
    {
        public virtual ICollection<Material> Materials { get; set; }
        #region Properties
        public int CurricularId { get; set; }
        public string Name { get; set; }
        #endregion

        public Curricular()
        {

            Materials = new HashSet<Material>();
        }

        public void addMaterial(Material materiaal)
        {

            Materials.Add(materiaal);

        }

    }
}