using System.Threading.Tasks;
using Familee.App.Infrastructure.Helpers;
using Familee.App.Infrastructure.Route;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Familee.App
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");
      
      ConfigureServices(builder.Services);

      await builder.Build().RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<INavigator, Navigator>();
      services.AddSingleton<IFamilyMemberImageResolver, FamilyMemberImageResolver>();
      
      services.AddMatBlazor();
      services.AddMatToaster(c =>
      {
        c.Position = MatToastPosition.BottomFullWidth;
        c.PreventDuplicates = true;
        c.NewestOnTop = true;
        c.ShowCloseButton = true;
        c.VisibleStateDuration = 3000;
      });
    }
  }
}