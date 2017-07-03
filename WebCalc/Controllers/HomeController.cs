using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        private IOperationRepository OperationRepository { get; set; }

        private IOperResultRepository OperResultRepository { get; set; }

        public HomeController()
        {
            UserRepository = new UserRepository();

            OperationRepository = new OperationRepository();

            OperResultRepository = new OperResultRepository();
        }

        public ActionResult Index()
        {
            var ur = new UserRepository();

            ViewBag.Users = UserRepository.GetAll();

            return View();
        }

        
        public ActionResult About_User(long Id)
        {
            ViewBag.Users = UserRepository.GetUserInfo(Id);
            
            return View();
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