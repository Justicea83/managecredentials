using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageCredentials.Models;
using ManageCredentials.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace ManageCredentials
{
    public class Startup
    {
        public Startup(IConfiguration config,IHostingEnvironment env)
        {
            Configuration = config;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();
            services.AddSession();
            services.AddTransient<IRepository<BusinessLead>,GenericRepository<BusinessLead>>();
            services.AddTransient<IRepository<Contact>,GenericRepository<Contact>>();
            services.ConfigureApplicationCookie(opts => 
            {
                opts.LoginPath = "/Home/Login";
            });
            services.AddMvc();
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseSession();
                app.UseStatusCodePages();
                app.UseAuthentication();
                app.UseMvcWithDefaultRoute();
            }

           
        }
    }
}
