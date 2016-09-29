using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
    public interface IMaterialRepository
    {
        Material FindBy(int materialId);
        IQueryable<Material> FindAll();
        IQueryable<Material> FindAllMaterialsWithSearString(string searchString);
        IQueryable<ReservedMaterial> FindAllAvailableForWeek(DateTime week);
        void SaveChanges();
        void Add(Material material);
        void Delete(Material splitsboom);
        Material FindByName(string naam);
    }
}
