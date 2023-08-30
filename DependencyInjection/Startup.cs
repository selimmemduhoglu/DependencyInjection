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


            //services.AddSingleton<INumGenerator, NumGenerator>(); // Uygulama aay�a kalkt���nda burada o instance � retir ve uygulama kapanana kadar o instance ayakta olur ne zaman  ki uygulama kapan�r o zaman o nesne bellekten silinir.
            //Singleton'da sadece ilk �a�r�ld���nda create edilir ondan sonra create edilmez.(�lk �a�r�ld���nda create edilmesi proje aya�a kalkt���nda demek oluyor zaten) 
            
            //AddScoped<INumGenerator, NumGenerator>(); //  Projeye ayaktayken her request i�in yeni bir instance olu�turuyor.
            //services.AddScoped<INumGenerator2, NumGenerator2>();
            services.AddTransient<INumGenerator, NumGenerator>(); //Scope benzer fakat araar�ndaki fark scope request bazl� nesne �retilirken Transient te ise request i�inde de nesne �retilebilir.
            services.AddTransient<INumGenerator2, NumGenerator2>();
            //Transient te request i�inde bir den fazla nesne �reitlebilir
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
