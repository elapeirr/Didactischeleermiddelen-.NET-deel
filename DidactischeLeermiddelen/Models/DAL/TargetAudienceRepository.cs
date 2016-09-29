using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class TargetAudienceRepository : ITargetAudienceRepository
    {
        private TeachingAidsContext context;
        private DbSet<TargetAudience> targetAudiences;

        public TargetAudienceRepository(TeachingAidsContext context)
        {
            this.context = context;
            targetAudiences = context.TargetAudiences;
        }

        public IQueryable<TargetAudience> FindAll()
        {
            return targetAudiences.OrderBy(t => t.Name);
        }

        public TargetAudience FindBy(int targetAudienceId)
        {
            throw new NotImplementedException();
        }
    }
}