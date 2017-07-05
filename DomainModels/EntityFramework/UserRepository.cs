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

        public UserContext db { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();

            this.db = new UserContext();
        }

        public User Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            user.IsDeleted = true;
            Update(user);
        }

        public User Get(long id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id && u.IsDeleted == false);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.Where(u => !u.IsDeleted).ToList();
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
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
