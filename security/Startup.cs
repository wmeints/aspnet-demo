using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace security
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            
            // OPTIONAL: Use a custom authorization handler to implement resource-based
            // authorization in the application.
            // services.AddTransient<IAuthorizationHandler,AdminUserHandler>();
            
            // The authorization for the application is defined in a number of policies.
            // Each policy defines what the user has to comply to in order to get access.
            services.AddAuthorization(authorization => {
                authorization.AddPolicy("Anonymous", policy =>  policy.RequireDelegate((context,requirement) => {
                    // When none of the identities are authenticated the user is anonymous.
                    // So the requirement was succesful.
                    if(context.User.Identities.All(identity => !identity.IsAuthenticated)) {
                        context.Succeed(requirement);    
                    } else {
                        context.Fail();
                    }
                }));
                
                authorization.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());  
            }); 
            
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();
            
            // Allow users to log on using a username + password.
            // The authentication ticket is stored in a cookie.
            app.UseCookieAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.LoginPath = "/Account/Logon";
                options.LogoutPath = "/Account/Logoff";
            });      
            
            app.UseMvc(routes => {
                routes.MapRoute("DefaultRoute",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index"});
            });
        }
    }
}
