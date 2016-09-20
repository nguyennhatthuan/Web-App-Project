using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCinema.Startup))]
namespace WebCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
