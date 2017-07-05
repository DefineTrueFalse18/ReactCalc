using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class CalcModel
    {
        public CalcModel()
        {
            OperationList = new List<SelectListItem>();
        }

        public string Operation { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Result { get; set; }

        public double[] Arguments
        {
            get
            {
                return new[] { X ?? 0, Y ?? 0 };
            }
        }

        public IEnumerable<SelectListItem> OperationList { get; set; }
    }
}