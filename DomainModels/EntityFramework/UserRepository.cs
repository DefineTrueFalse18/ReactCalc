using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels.Models;
using System.Data.Entity;

namespace DomainModels.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private CalcContext context { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();
        }

        public User Create()
        {
            return new User();
        }

        public void Delete(User user)
        {
            user.IsDeleted = true;
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public User Get(long id)
        {
            return context.Users.FirstOrDefault(u => !u.IsDeleted && u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.Where(u => !u.IsDeleted).ToList();
        }

        public void Update(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public bool Valid(string userName, string password)
        {
            return context.Users.Count(u => !u.IsDeleted && u.Login == userName && u.Password == password) == 1;
        }

        public User GetByName(string name)
        {
            return context.Users.FirstOrDefault(u => !u.IsDeleted && u.Login == name);
        }
    }
}
