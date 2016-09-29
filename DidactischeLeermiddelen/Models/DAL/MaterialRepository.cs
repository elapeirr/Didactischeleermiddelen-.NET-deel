using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class MaterialRepository : IMaterialRepository
    {
        private TeachingAidsContext context;
        private DbSet<Material> materials;

        public MaterialRepository(TeachingAidsContext context)
        {
            this.context = context;
            materials = context.Materials;
        }

        public IQueryable<Material> FindAll()
        {
            return materials.OrderBy(m=>m.Name);
        }

        public IQueryable<Material> FindAllMaterialsWithSearString(string searchString)
        {
            return materials.Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString) || s.TargetAudiences.Any(t => t.Name.Contains(searchString)) || s.Curriculars.Any(c => c.Name.Contains(searchString)));
        }

        
        public Material FindBy(int materialId)
        {
            return materials.FirstOrDefault(m => m.MaterialId == materialId);
        }

        public IQueryable<Material> GetMaterials()
        {
            return materials;
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Add(Material materiaal)
        {
            materials.Add(materiaal);
        }

        public void Delete(Material materiaal)
        {
            materials.Remove(materiaal);
        }

        public IQueryable<ReservedMaterial> FindAllAvailableForWeek(DateTime week)
        {
          throw new NotImplementedException();
        }

        public Material FindByName(string naam)
        {
            return materials.SingleOrDefault(m => m.Name == naam);
           
        }
    }
}