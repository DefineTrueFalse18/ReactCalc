using DomainModels.EntityFramework;
using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IOperationResultRepository ORRepository { get; set; }
        protected IUserRepository UserRep { get; set; }
        protected IOperationRepository OperRep { get; set; }
        protected ILikeRepository LikeRepository { get; set; }

        public BaseController(IOperationResultRepository ORRepository,
            IUserRepository UserRep,
            ILikeRepository LikeRepository,
            IOperationRepository OperRep)
        {
            this.OperRep = OperRep;
            this.ORRepository = ORRepository;
            this.UserRep = UserRep;
            this.LikeRepository = LikeRepository;
        }

        protected User GetCurrentUser()
        {
            return UserRep.GetByName(User.Identity.Name);
        }
    }
}