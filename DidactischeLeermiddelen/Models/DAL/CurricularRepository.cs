using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class CurricularRepository : ICurricularRepository
    {
        private TeachingAidsContext context;
        private DbSet<Curricular> curriculars;

        public CurricularRepository(TeachingAidsContext context)
        {
            this.context = context;
            curriculars = context.Curriculars;
        }

        public IQueryable<Curricular> FindAll()
        {
            return curriculars.OrderBy(c => c.Name);

        }
        public Curricular FindBy(int curricularId)
        {
            throw new NotImplementedException();
        }

        public Curricular FindByName(String name) {
            return curriculars.Where(c => c.Name == name).FirstOrDefault();

        }
    }
}