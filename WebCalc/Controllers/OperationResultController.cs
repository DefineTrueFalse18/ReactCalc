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

            var likes = LikeRepository.GetLikes(curUser.Id).Select(it => it.ResultId);

            foreach (var result in results)
            {
                result.IsLiked = likes.Contains(result.Id);
            }
            return View(results);
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

            var like = LikeRepository.GetLikes(curUser.Id)
                .FirstOrDefault(it => it.UserId == curUser.Id && it.ResultId == id);

            if (like != null)
            {
                //Dislike
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "Like" });
            }

            // Создать лайк
            like = LikeRepository.Create();

            // Заполнить свойства
            like.UserId = curUser.Id;
            like.ResultId = result.Id;

            // Сохранить
            LikeRepository.Update(like);

            // Вернуться к списку операций
            return Json(new { Success = true, Name = "Dislike" });
        }
    }
}