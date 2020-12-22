using System.Threading.Tasks;
using Blazored.LocalStorage;
using Familee.App.Infrastructure.Gateways;
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

      services.AddTransient<IFamilyMemberGateway, FamilyMemberLocalStorageGateway>();
      
      services.AddMatBlazor();
      services.AddMatToaster(c =>
      {
        c.Position = MatToastPosition.BottomRight;
        c.PreventDuplicates = true;
        c.NewestOnTop = true;
        c.ShowCloseButton = true;
        c.VisibleStateDuration = 3000;
      });

      services.AddBlazoredLocalStorage();
    }
  }
}