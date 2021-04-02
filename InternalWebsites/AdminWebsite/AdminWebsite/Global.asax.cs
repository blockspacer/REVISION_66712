using System;
using System.Web;
using System.Web.UI;
using Roblox.Platform.ErrorModels;
using Roblox.Web.Util;

namespace AdminWebsite
{
    public class MvcApplication : HttpApplication
    {
        // Lean And Mean represents the EXTREMELY detailed error views
        protected void Application_Start(object sender, EventArgs e)
        {
            string JQueryVer = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
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
#if DEBUG

            Exception ex = Server.GetLastError();
            IDetailedRobloxError error = new IDetailedRobloxError { Where = ex.Source, What = ex.Message, Stack = ex.StackTrace };
            Errors.RespondWithADetailedError(error, Context.Response, true);

#else
            IDefaultRobloxError error = new IDefaultRobloxError { Code = 500, Message = "An error has occured" };
            Errors.RespondWithADefaultError(error, Context.Response, true);
#endif
            return;
        }
        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}