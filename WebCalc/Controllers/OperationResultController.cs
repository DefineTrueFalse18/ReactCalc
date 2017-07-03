using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepository OperationResultRepository { get; set; }

        public OperationResultController()
        {
            OperationResultRepository = new DomainModels.EntityFramework.OperationResultRepository();
        }

        public ActionResult ViewOperResults(long Id)
        {
            var operResult = OperationResultRepository.Get(Id);

            return View(operResult);
        }
    }
}