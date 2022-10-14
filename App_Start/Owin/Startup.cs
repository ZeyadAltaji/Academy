using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
[assembly: OwinStartup(typeof(Academy.App_Start.Owin.Startup))]

namespace Academy.App_Start.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            CookieAuthenticationOptions cookieAuthenticationOptions = new CookieAuthenticationOptions();
            cookieAuthenticationOptions.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            cookieAuthenticationOptions.LoginPath = new PathString("/Account/Login");
            app.UseCookieAuthentication(cookieAuthenticationOptions);
        }
    }
}
