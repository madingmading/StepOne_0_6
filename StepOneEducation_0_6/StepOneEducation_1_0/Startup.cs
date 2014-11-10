using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StepOneEducation_1_0.Startup))]
namespace StepOneEducation_1_0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
