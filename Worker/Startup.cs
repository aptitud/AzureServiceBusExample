using Owin;
using Microsoft.Owin.Cors;

namespace Worker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
           
        }
    }
}
