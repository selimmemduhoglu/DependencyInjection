using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DependencyInjection.NumGenerator;

namespace DependencyInjection
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the con tainer.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            //services.AddSingleton<INumGenerator, NumGenerator>(); // Uygulama aayða kalktýðýnda burada o instance ý retir ve uygulama kapanana kadar o instance ayakta olur ne zaman  ki uygulama kapanýr o zaman o nesne bellekten silinir.
            //Singleton'da sadece ilk çaðrýldýüýnda create edilir ondan sonra create edilmez.(Ýlk çaðrýldýðýnda create edilmesi proje ayaða kalktýðýnda demek oluyor zaten) 
            
            //AddScoped<INumGenerator, NumGenerator>(); //  Projeye ayaktayken her request için yeni bir instance oluþturuyor.
            //services.AddScoped<INumGenerator2, NumGenerator2>();
            services.AddTransient<INumGenerator, NumGenerator>(); //Scope benzer fakat araarýndaki fark scope request bazlý nesne üretilirken Transient te ise request içinde de nesne üretilebilir.
            services.AddTransient<INumGenerator2, NumGenerator2>();
            //Transient te request içinde bir den fazla nesne üreitlebilir
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
