using PGP.Api.App_Start;
using System.Web.Http;
using System.Web.Routing;

namespace PGP.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Ninject
            NinjectConfig.SetupNinject();
        }
    }
}