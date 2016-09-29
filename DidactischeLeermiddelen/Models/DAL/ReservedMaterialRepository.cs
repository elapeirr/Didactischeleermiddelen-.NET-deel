using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class ReservedMaterialRepository : IReservedMaterialRepository
    {
        private TeachingAidsContext context;
        private DbSet<ReservedMaterial> reservedmaterials;
        public ReservedMaterialRepository(TeachingAidsContext context)
        {
            this.context = context;
            reservedmaterials = context.Reservations;
        }
        public void Add(ReservedMaterial material)
        {
            reservedmaterials.Add(material);
        }
        
        public void Delete(ReservedMaterial material)
        {
            reservedmaterials.Remove(material);
        }

        public IQueryable<ReservedMaterial> FindAll()
        {
            return reservedmaterials.OrderBy(m => m.ReservedMaterialId);
        }

        public ReservedMaterial FindByName(string name)
        {
            return reservedmaterials.FirstOrDefault(m => m.name == name);
        }

        public ReservedMaterial FindBy(int materialId)
        {
           return  reservedmaterials.FirstOrDefault(m => m.ReservedMaterialId == materialId);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}