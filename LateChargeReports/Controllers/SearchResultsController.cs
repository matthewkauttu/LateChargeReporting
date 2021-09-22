using LateChargeReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Kendo.Mvc.Export;
using Telerik.Documents.SpreadsheetStreaming;
using System.IO;

namespace LateChargeReports.Controllers
{
    public class SearchResultsController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(DateRange dates)
        {
            if (ModelState.IsValid)
            {
                Results patientData = DataAccessLayer.GetData(dates.StartDate, dates.EndDate);
                return View("Results", patientData);
            }
            return View();
        }

        public ActionResult Select([DataSourceRequest]DataSourceRequest request, List<sqlData> patientDataList)
        {
            return Json(patientDataList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Results(Results searchResults)
        {
            return View(searchResults);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Results(DateRange dates)
        {
            if (ModelState.IsValid)
            {
                Results patientData = DataAccessLayer.GetData(dates.StartDate, dates.EndDate);
                return View(patientData);
            }
            return View();
        }
    }
}