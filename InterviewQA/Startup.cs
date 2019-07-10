using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InterviewQAApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewQAApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config2 = Configuration.GetConnectionString("InterviewQAAPIConnection");
            services.AddDbContext<InterviewQAContext>(o => o.UseSqlServer(config2));
            //services.AddDbContext<InterviewQAContext>
            //    (opt => opt.UseSqlServer(Configuration["Data:InterviewQAAPIConnection:ConnectionString"]));
            //services.AddDbContext<InterviewQAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("InterviewQAAPIConnection")));
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                        );
            app.UseMvc();
        }
    }
}
