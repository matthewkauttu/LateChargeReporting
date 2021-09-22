using LateChargeReports.Controllers;
using MvcLocalSecurity.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LateChargeReports
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            // "HCA_UserSoap12" is a binding name in the Web.config setting "configuration/system.serviceModel/bindings"
            var User = new HCAUser.HCA_UserSoapClient("HCA_UserSoap12");
            var UserObj = User.ValidateUser(GetUserId(), "LateChargesApp");
            
            var UserSecurity = UserObj.SecurityLevel;

            var applicationAccount = ((HttpApplication)sender).User;
            HttpContext.Current.User = new ApplicationPrincipal(applicationAccount, UserSecurity, UserObj.UserName);
        }

        private string GetUserId()
        {
            // What this is doing is getting the ¾ from the PC They start with HCA/”3/4” so we strip off the “HCA\”
            return Context.User.Identity.Name.Substring(4);
        }

        public void Application_Error(SecurityException ex)
        {
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "AccountUnauthorized");
            routeData.Values.Add("Summary", "Account Unauthorized Error");
            routeData.Values.Add("Description", ex.Message);
            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}
