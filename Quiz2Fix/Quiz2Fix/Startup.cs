using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quiz2Fix.Startup))]
namespace Quiz2Fix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
