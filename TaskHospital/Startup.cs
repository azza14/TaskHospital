using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskHospital.Startup))]
namespace TaskHospital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
