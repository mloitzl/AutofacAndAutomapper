using AutofacAndAutomapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AutofacAndAutomapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac();
            ConfigureWebApi();
        }
    }
}