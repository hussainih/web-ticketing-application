
using Microsoft.Owin;

using Owin;


[assembly: OwinStartupAttribute(typeof(Ticketing.Startup))]
namespace Ticketing
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
           
        }
      

          
        
    }
}
