using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope()){
                var Service =scope.ServiceProvider;
                var loggerFactory=Service.GetRequiredService<ILoggerFactory>();
                try{
                        var context= Service.GetRequiredService<StoreContext>();
                        await context.Database.MigrateAsync();
                        await StoreContextSeed.SeedAsync(loggerFactory,context);
                }
                catch(Exception ex){
                    var logger= loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex,"An error occured during migration");
                }
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
