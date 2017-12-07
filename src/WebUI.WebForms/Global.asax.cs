using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebUI.Services;

namespace WebUI.WebForms
{
    public class Global : HttpApplication
    {
        public static IServiceProvider ServiceProvider;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureServices(ConfigureServices);
            var host = hostBuilder.Build();

            ServiceProvider = host.Services;
        }

        void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ValuesService>(client => 
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["valuesUri"]));
        }
    }
}