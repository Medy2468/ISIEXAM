using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISIEXAM.Startup))]
namespace ISIEXAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
