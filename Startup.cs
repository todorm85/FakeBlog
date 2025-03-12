using CyberPost.Models;
using System.Web;
using System;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(CyberPost.Startup))]
namespace CyberPost
{
    public partial class Startup
    {
        private const string RegisterPath = "/Account/Register";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Use(async (context, next) =>
            {
                if (!context.Request.Uri.AbsolutePath.Equals(RegisterPath, StringComparison.InvariantCultureIgnoreCase))
                {
                    var um = context.GetUserManager<ApplicationUserManager>();
                    if (um.Users.Count() == 0)
                    {
                        context.Response.Redirect(RegisterPath);
                        return;
                    }
                }

                await next.Invoke();
            });
        }
    }
}
