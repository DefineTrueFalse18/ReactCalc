using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
    public class LikeRepository : ILikeRepository
    {
        private CalcContext context { get; set; }

        public LikeRepository()
        {
            this.context = new CalcContext();
        }

        public UserFavouriteResult Create()
        {
            return new UserFavouriteResult();
        }

        public void Delete(UserFavouriteResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public UserFavouriteResult Get(long id)
        {
            return context.UserFavouriteResult.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserFavouriteResult> GetAll()
        {
            return context.UserFavouriteResult.ToList();            
        }

        public void Update(UserFavouriteResult result)
        {
            context.Entry(result).State = result.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
