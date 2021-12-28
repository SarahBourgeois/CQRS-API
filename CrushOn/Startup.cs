using System;
using System.IO;
using CrushOn.Infrastructure.Abstract.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace E.Showtime.Api.Http
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMvc()
                    .UseCors("default");

            }


            if (!env.IsProduction())
            {
      
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddTransient<IServiceResponseWrapper, ServiceResponseWrapper>();

            services.AddService();
            services.AddBusiness();
            services.AddCors(option => option.AddPolicy("default", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

            //services.Configure<MvcOptions>(options => options.Filters.Add(new CorsAuthorizationFilterFactory("default")));
            services.AddMemoryCache();




        }
    }
}