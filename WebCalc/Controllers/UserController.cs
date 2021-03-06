﻿using DomainModels.Models;
using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
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

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var user = UserRepository.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
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