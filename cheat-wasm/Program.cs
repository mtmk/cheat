using System;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace cheat_wasm
{
    public class Program
    {
        public static readonly List<string> Words = new List<string>();

        static Program()
        {
            using var sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("cheat-wasm.words_alpha.txt"));
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Words.Add(line);
            }
        }
        
        public static async Task Main(string[] args)
        {
            
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
