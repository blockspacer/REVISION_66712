using System.Web;

namespace AdminWebsite.Account
{
    /// <summary>
    /// Summary description for Logout
    /// </summary>
    public class Logout : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}