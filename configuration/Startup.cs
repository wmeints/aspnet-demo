using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;

namespace helloworld
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder(".")
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddInstance(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute("DefaultRoute",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" });
            });
        }
    }
}
