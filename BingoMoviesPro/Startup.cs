using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BingoMoviesPro.Startup))]
namespace BingoMoviesPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
