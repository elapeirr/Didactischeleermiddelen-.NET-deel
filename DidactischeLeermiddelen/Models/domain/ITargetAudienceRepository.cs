using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
    public interface ITargetAudienceRepository
    {
        TargetAudience FindBy(int curricularId);
        IQueryable<TargetAudience> FindAll();
    }
}
