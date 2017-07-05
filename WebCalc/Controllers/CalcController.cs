using DomainModels.EntityFramework;
using DomainModels.Models;
using DomainModels.Repository;
using ReactCalc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private IOperationResultRepository ORRepository { get; set; }
        private IUserRepository UserRep { get; set; }

        private IOperationRepository OperRep { get; set; }

        private Calc Calc { get; set; }

        public CalcController(IOperationResultRepository orrepository, IUserRepository UserRep)
        {
            Calc = new Calc();
            OperRep = new OperationRepository();
            ORRepository = orrepository;
            this.UserRep = UserRep;
        }

        public ActionResult Index()
        {
            CalcModel model = new CalcModel();
            ViewBag.Operations = new SelectList(OperRep.GetAll(), "Name", "FullName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);

            if (operation != null)
            {
                var operId = 1;
                var inputData = string.Join(",", model.Arguments); ;

                var oldResult = ORRepository.GetOldResult(operId, inputData);
                if (!double.IsNaN(oldResult))
                {
                    model.Result = oldResult;
                }
                else
                {
                    #region вычисление
                    model.Result = operation.Execute(model.Arguments);

                    var rec = ORRepository.Create(null);

                    //текущего пользователя назначаем автором
                    var currUser = UserRep.GetByName(User.Identity.Name);
                    rec.AuthorId = currUser.Id;


                    //хак
                    rec.OperationId = 1;

                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = inputData;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                    #endregion
                }

                ViewBag.Operations = new SelectList(OperRep.GetAll(), "Name", "FullName");

                return View(model);
            }

            return View();
        }
    }
}