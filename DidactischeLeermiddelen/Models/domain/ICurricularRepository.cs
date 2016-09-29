using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
    public interface ICurricularRepository
    {
        Curricular FindBy(int curricularId);
        IQueryable<Curricular> FindAll();
    }
}
