using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class CompanyRepository : ICompanyRepository
    {
        private TeachingAidsContext context;
        private DbSet<Company> companies;

        public CompanyRepository(TeachingAidsContext context)
        {
            this.context = context;
            companies = context.Companies;
        }
        public IQueryable<Company> FindAll()
        {
            return companies;
        }

        public Company FindBy(int curricularId)
        {
            throw new NotImplementedException();
        }
    }
}