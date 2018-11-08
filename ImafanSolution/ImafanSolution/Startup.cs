using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImafanSolution.Startup))]
namespace ImafanSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
