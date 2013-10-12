using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WA_Food_Coalition.Startup))]
namespace WA_Food_Coalition
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
