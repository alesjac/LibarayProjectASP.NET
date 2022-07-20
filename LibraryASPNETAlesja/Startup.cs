using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryASPNETAlesja.Startup))]
namespace LibraryASPNETAlesja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
