using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrariDenisKoleci.Startup))]
namespace LibrariDenisKoleci
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
