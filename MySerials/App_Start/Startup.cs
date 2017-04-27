using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySerials.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


[assembly: OwinStartup(typeof(MySerials.App_Start.Startup))]
namespace MySerials.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(
                ApplicationContext.Create
                );
            app.CreatePerOwinContext<UserManager>(
                UserManager.Create
                );
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login")
                }
                );
        }
    }
}