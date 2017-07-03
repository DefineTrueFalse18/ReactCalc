using DomainModels.Models;
using DomainModels.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController()
        {
            UserRepository = new DomainModels.EntityFramework.UserRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();

            return View();
        }

        public ActionResult About_User(long Id)
        {
            var user = UserRepository.Get(Id);

            //если юзер удален,то открываем о нем подробности, иначе на домашнюю
            //нужно чтобы если кто-то решит сам прописать адрес, поставить его на место
            if (user != null)
            {
                return View(user);
            }
            else
            {
                ViewBag.Users = UserRepository.GetAll();

                return View("Index");
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            var usr = UserRepository.Create(user);
            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            UserRepository.Update(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var user = UserRepository.Get(id);
            UserRepository.Delete(user);

            return View("Index");
        }
    }
}