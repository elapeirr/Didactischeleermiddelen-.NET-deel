using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Models.domain
{
    public interface IUserRepository
    {
        IQueryable<User> FindAll();
        User FindBy(string UserName);
        void Add(User user);
        void AddToCurrentUserWishlist(Material material);
        void SaveChanges();
        User FindById(int hulp);
    }
}
