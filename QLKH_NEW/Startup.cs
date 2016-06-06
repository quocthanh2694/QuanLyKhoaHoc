using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLKH_NEW.Startup))]
namespace QLKH_NEW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
