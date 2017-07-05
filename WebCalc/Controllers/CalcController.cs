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
        private IUserRepository UserRepository { get; set; }
        private IOperationRepository OperationRepository { get; set; }

        private Calc Calc { get; set; }

        public CalcController(IOperationResultRepository ORRepository,
            IUserRepository UserRepository,
            IOperationRepository OperationRepository)
        {
            Calc = new Calc();
            this.ORRepository = ORRepository;
            this.UserRepository = UserRepository;
            this.OperationRepository = OperationRepository;
        }

        public ActionResult Index()
        {
            var model = new CalcModel();
            model.OperationList = Calc.Operations
                .Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            model.OperationList = Calc.Operations
                .Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}", Selected = model.Operation == o.Name });

            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);

            if (operation != null)
            {

                var dbOper = OperationRepository.GetByName(operation.Name);
                var operId = dbOper.Id;
                var inputData = string.Join(",", model.Arguments);

                var oldResult = ORRepository.GetOldResult(operId, inputData);
                if (!double.IsNaN(oldResult))
                {
                    model.Result = oldResult;
                }
                else
                {
                    #region вычисление
                    model.Result = operation.Execute(model.Arguments);

                    var rec = ORRepository.Create();

                    //текущего пользователя назначаем автором
                    var currUser = UserRepository.GetByName(User.Identity.Name);
                    rec.AuthorId = currUser.Id;
                    rec.OperationId = operId;
                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = inputData;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                    #endregion
                }
                return View(model);
            }
            return View();
        }
    }
}