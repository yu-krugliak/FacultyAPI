using System;
using System.Linq;
using Db.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.Integration.Test
{
    public class TestWebApplicationFactory <TStartup>: WebApplicationFactory<TStartup> where TStartup : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                var aa = services.FirstOrDefault(a => "IHostedService" == a.GetType().Name);

                services.RemoveAll(typeof(IHostedService));
                var a = services.FirstOrDefault(a => typeof(IHost) == a.GetType());

                services.AddDbContext<Context>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

                var aaa = services.FirstOrDefault(a => typeof(IHostedService) == a.GetType());

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<Context>();
                    db.Database.EnsureCreated();

                }
            });
        
        }

    }
}