using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LateChargeReports.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccountUnauthorized()
        {
            return View();
        }
    }
}