using DomainModels.Repository;
using System.Web.Mvc;
using System.Linq;

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

            var likes = LikeRepository.GetAll()     // получаем все лайки (надо унести в репозиторий)
                .Where(u => u.UserId == curUser.Id) // фильтруем по текущему юзверю (надо унести в репозиторий)
                .Select(it => it.ResultId);         // достаем из лайков результаты операций

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

            var like = LikeRepository.GetAll()
                .FirstOrDefault(it => it.UserId == curUser.Id && it.ResultId == id); //унести в репозиторий

            if (like != null)
            {
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "like" });
            }

            // Создать лайк
            like = LikeRepository.Create();

            // Заполнить свойства
            like.UserId = curUser.Id;
            like.ResultId = result.Id;

            // Сохранить
            LikeRepository.Update(like);

            // Вернуться к списку операций
            return Json(new { Success = true, Name = "dislike" });
        }
    }
}