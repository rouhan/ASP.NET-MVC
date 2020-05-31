using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRWork.Startup))]
namespace SignalRWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
