using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace helloworld
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes => {
                routes.MapRoute("DefaultRoute", 
                    "{controller}/{action}/{id?}", 
                    new { controller = "Home", action = "Index"});
            });
        }
    }
}
