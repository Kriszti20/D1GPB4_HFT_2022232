using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D1GPB4_HFT_2022232.Endpoint.Services;
using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace D1GPB4_HFT_2022232.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<ISongLogic, SongLogic>();
            services.AddTransient<IAuthorLogic, AuthorLogic>();

            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            services.AddTransient<SongDbContext, SongDbContext>();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:23072"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
