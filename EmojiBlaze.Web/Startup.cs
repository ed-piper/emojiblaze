using Blazor.Fluxor;
using EmojiBlaze.Models.Board;
using EmojiBlaze.Models.Store.Game;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace EmojiBlaze.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICardGenerator, CardGenerator>();
            services.AddFluxor(options => options
                .UseDependencyInjection(typeof(GameState).Assembly)
                .AddMiddleware<Blazor.Fluxor.ReduxDevTools.ReduxDevToolsMiddleware>()
                .AddMiddleware<Blazor.Fluxor.Routing.RoutingMiddleware>()
            );
        }
        
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
