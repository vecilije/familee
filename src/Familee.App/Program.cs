using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Familee.App.Infrastructure;
using Familee.App.Infrastructure.Route;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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