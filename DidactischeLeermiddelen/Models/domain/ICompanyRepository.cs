using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
    public interface ICompanyRepository
    {
        Company FindBy(int curricularId);
        IQueryable<Company> FindAll();
    }
}
