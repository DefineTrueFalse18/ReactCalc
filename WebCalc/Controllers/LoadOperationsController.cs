using DomainModels.EntityFramework;
using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class LoadOperationsController : Controller
    {
        private ILoadOperationsRepository LoadOperRep { get; set; }

        private IOperationRepository OperRep { get; set; }

        public LoadOperationsController()
        {
            LoadOperRep = new LoadOperationsRepository();
            OperRep = new OperationRepository();
        }

        public ActionResult Index()
        {
            var opers = OperRep.GetAll();

            LoadOperRep.Create(null);

            return RedirectToAction("Index", "Calc");
        }
    }
}