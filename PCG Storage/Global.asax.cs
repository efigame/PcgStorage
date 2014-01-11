using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Pcg_Storage
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "", "~/Webforms/User/Login.aspx");
            routes.MapPageRoute("", "user/new", "~/Webforms/User/New.aspx");
            routes.MapPageRoute("", "user/forgotten", "~/Webforms/User/ForgottenPassword.aspx");
            routes.MapPageRoute("", "{userid}/party/index", "~/Webforms/Party/Index.aspx");
            routes.MapPageRoute("", "{userid}/party/new", "~/Webforms/Party/New.aspx");
            routes.MapPageRoute("", "{userid}/party/{partyid}", "~/Webforms/Party/View.aspx");
            routes.MapPageRoute("", "{userid}/party/{partyid}/edit", "~/Webforms/Party/Edit.aspx");
            routes.MapPageRoute("", "{userid}/party/{partyid}/character/{characterid}", "~/Webforms/Character/View.aspx");
            routes.MapPageRoute("", "{userid}/party/{partyid}/character/{characterid}/edit", "~/Webforms/Character/Edit.aspx");
        }
    }
}