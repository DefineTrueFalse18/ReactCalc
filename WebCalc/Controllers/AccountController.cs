using DomainModels.Models;
using DomainModels.Repository;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace WebCalc.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public AccountController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string name, string password)
        {
            // поиск пользователя в бд
            if (UserRepository.Valid(name, password))
            {
                FormsAuthentication.SetAuthCookie(name, true);
                return RedirectToAction("Index", "Calc");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}