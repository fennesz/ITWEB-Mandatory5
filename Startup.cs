using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Models;
using Microsoft.EntityFrameworkCore;

namespace ITWEB_Mandatory5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAutoMapper();

            var Components = new Component[] {
                new Component{ Id = 1, ComponentNumber = 1, SerialNo = "1", Status = ComponentStatus.Available, AdminComment = "a", UserComment = "a", ComponentTypeId = 1},
                new Component{ Id = 2, ComponentNumber = 10, SerialNo = "2", Status = ComponentStatus.Available, AdminComment = "b", UserComment = "b", ComponentTypeId = 2},
                new Component{ Id = 2, ComponentNumber = 100, SerialNo = "3", Status = ComponentStatus.Available, AdminComment = "c", UserComment = "c", ComponentTypeId = 30},
            };

            services.AddTransient<IRepository<Component>>(_ => new ListRepository<Component>(Components));

            var Categories = new Category[] {
                new Category { Id = 1, Name = "Transistors"},
                new Category { Id = 2, Name = "Diodes"},
                new Category { Id = 3, Name = "Resistors"},
            };

            services.AddTransient<IRepository<Category>>(_ => new ListRepository<Category>(Categories));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
