using DomainModels.Repository;
using System.Web.Mvc;
using System.Linq;
using DomainModels.Models;

namespace WebCalc.Controllers
{
    public class OperationResultController : BaseController
    {
        public OperationResultController(IOperationResultRepository orrepository, IUserRepository UserRepository, ILikeRepository LikeRepository, IOperationRepository OperationRepository)
            : base(orrepository, UserRepository, LikeRepository, OperationRepository)
        {
        }

        public ActionResult Index()
        {
            var curUser = GetCurrentUser();

            var results = ORRepository.GetByUser(curUser);

            // var likes = LikeRepository.GetLikes(curUser.Id).Select(it => it.ResultId);

            var likes = LikeRepository.GetAll()     // получаем все лайки
                .Where(u => u.User.Id == curUser.Id) // фильтруем по текущему юзеру
                .Select(it => it.Result.Id);         // достаем из лайков результаты операций  

            foreach (var result in results)
            {
                result.IsLiked = likes.Contains(result.Id);
            }
            return View(results);
        }

        public ActionResult Favourite()
        {
            var curUser = GetCurrentUser();
            return View(ORRepository.GetByUser(curUser));
        }

        [HttpPost]
        public JsonResult Like(long id)
        {
            var result = ORRepository.Get(id);            

            if (result == null)
            {
                return Json(new { Success = false, Error = "Не удалось найти результат" });
            }

            var curUser = GetCurrentUser();

            //var like = LikeRepository.GetLikes(curUser.Id)
            //    .FirstOrDefault(it => it.UserId == curUser.Id && it.ResultId == id);

            var like = LikeRepository.GetAll().FirstOrDefault(it => it.User.Id == curUser.Id && it.Result.Id == id);

            if (like != null)
            {
                //Dislike
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "Like" });
            }

            // Создать лайк
            like = LikeRepository.Create();

            // Заполнить свойства
            like.User = curUser;
            like.Result = result;

            // Сохранить
            LikeRepository.Update(like);

            // Вернуться к списку операций
            return Json(new { Success = true, Name = "Dislike" });
        }
    }
}