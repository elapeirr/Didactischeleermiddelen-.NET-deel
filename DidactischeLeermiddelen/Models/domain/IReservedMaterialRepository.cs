using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
  public  interface IReservedMaterialRepository
    {
        ReservedMaterial FindBy(int materialId);
        IQueryable<ReservedMaterial> FindAll();
      ReservedMaterial FindByName(String name);
        void SaveChanges();
        void Add(ReservedMaterial material);
        void Delete(ReservedMaterial material);
    }
}
