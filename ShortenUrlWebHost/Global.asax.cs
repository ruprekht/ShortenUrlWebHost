using ShortenUrl.EntityFramework;
using ShortenUrl.Services.Infrastructure;
using ShortenUrlWebHost.App_Start;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;

namespace ShortenUrlWebHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            Database.SetInitializer(new ShortenUrlDbInitializer());
            EntityDbContext context = new EntityDbContext();
            context.Database.Initialize(true);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
