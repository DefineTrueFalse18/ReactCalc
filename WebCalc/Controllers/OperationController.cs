using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationController : Controller
    {
        private IOperationRepository OperationRepository { get; set; }

        public OperationController(IOperationRepository OperationRepository)
        {
            this.OperationRepository = OperationRepository;
        }

        public ActionResult AvaliableOperations()
        {
            ViewBag.Operation = OperationRepository.GetAll();

            return View();
        }
    }
}