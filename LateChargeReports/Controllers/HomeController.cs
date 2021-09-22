using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LateChargeReports.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string uid = System.Web.HttpContext.Current.User.Identity.Name.Replace(@"HCA\", "");
            var User = new HCAUser.HCA_UserSoapClient("HCA_UserSoap12");
            var UserObj = User.ValidateUser(uid, "LateChargesApp");

            if (UserObj.IsValidUser)
            {
                return RedirectToAction("Search", "SearchResults");
            }
            else
                return RedirectToAction("AccountUnauthorized", "Error");
        }
    }
}