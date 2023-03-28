using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Identity.Startup1))]

namespace Identity
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() 
                    {
                        AuthenticationType = "AppCookie",
                        LoginPath = new PathString("/Acount/Login")
                    }
            );
        }
    }
}
