using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        private IOperationRepository OperationRepository { get; set; }

        private IOperResultRepository OperResultRepository { get; set; }

        public UserController()
        {
            UserRepository = new DomainModels.EntityFramework.UserRepository();
        }

        public ActionResult Index()
        {
            var ur = new UserRepository();

            ViewBag.Users = UserRepository.GetAll();

            return View();
        }


        public ActionResult About_User(long Id)
        {
            var user = UserRepository.Get(Id);

            return View(user);
        }

        public ActionResult Operations()
        {
            var ur = new OperationRepository();

            ViewBag.Operation = OperationRepository.GetAll();

            return View();
        }

        public ActionResult OperationsResult()
        {
            var ur = new OperResultRepository();

            ViewBag.OperationResult = OperResultRepository.GetAll();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}