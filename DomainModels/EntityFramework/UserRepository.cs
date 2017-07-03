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
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id && u.IsDeleted == false);
        }

        public IEnumerable<User> GetAll()
        {
            var ListUser = context.Users.ToList();

            //данный метод удобнее, но он зачистил всю табллицу и он медленнее в 10 раз
            //ListUser.RemoveAll(x => x.IsDeleted = true);

            for (int i = ListUser.Count - 1; i >= 0; i--)
            {
                if (ListUser[i].IsDeleted == true)
                {
                    ListUser.Remove(ListUser[i]);
                }
            }

            return ListUser;
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool Valid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
