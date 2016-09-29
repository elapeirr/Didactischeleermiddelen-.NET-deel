using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DidactischeLeermiddelen.Models.domain;
using Microsoft.AspNet.Identity;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class UserRepository : IUserRepository
    {
        private TeachingAidsContext context;
        private DbSet<User> users;

        public UserRepository(TeachingAidsContext context)
        {
            this.context = context;
            users = context.Users;
        }
        public IQueryable<User> FindAll()
        {
            return users;
        }

        public User FindBy(string UserName)
        {
            return users.Where(s => s.UserName == UserName).FirstOrDefault();
        }

        public User FindById(int id)
        {
            return users.Where(s => s.UserId == id).SingleOrDefault();


        }
    

        public void Add(User user)
        {
            users.Add(user);
            SaveChanges();
        }

      

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void AddToCurrentUserWishlist(Material material)
        {
            throw new NotImplementedException();
        }
    }
}