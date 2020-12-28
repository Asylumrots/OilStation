using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OilStationCoreAPI.ConfigureSetup;
using OilStationCoreAPI.IdentityModel;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.Services;

namespace OilStationCoreAPI
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
            //跨域
            services.AddCorsSetup();

            //Swagger
            services.AddSwaggerSetup();

            #region 注册dbcontext和identity服务
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            //DbContext默认注册的Scoped生命周期 为了防止DI报错 依赖注入此项的Services不能是Singleton
            services.AddDbContext<OSMSContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region 定义identity注册登录规则
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            #endregion

            //授权
            services.AddAuthorizationSetup();

            //Jwt认证
            services.AddJwtSetup(Configuration);

            #region 依赖注入Services
            //默认注入
            //services.AddScoped<IStaffServices, StaffServices>();
            //services.AddScoped<IAspNetUsersServices, AspNetUsersServices>();
            //services.AddScoped<IAspNetRolesServices, AspNetRolesServices>();
            //services.AddScoped<IJobServices, JobServices>();
            //services.AddScoped<IOrganizationServices, OrganizationServices>();
            //services.AddScoped<IEntryServices, EntryServices>();
            //services.AddScoped<ILeaveServices, LeaveServices>();
            //services.AddScoped<IOilServices, OilServices>();
            //自动依赖注入1：根据类名后缀和前缀进行注入
            var assembly = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(a => a.Name.EndsWith("Services") && !a.Name.StartsWith("I"));

            foreach (var item in assembly)
            {
                services.AddScoped(item.GetInterfaces().FirstOrDefault(), item);
            }

            //自动注入方法2: 根据继承的接口来注册不同生命周期
            //var assemblyWeb = Assembly.GetExecutingAssembly();
            //services.AddAutoInjectionSetup(assemblyWeb);
            #endregion

            //易引发线程安全问题
            //services.AddSingleton(new OSMSContext());


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region 添加跨域
            //添加跨域
            app.UseCors("LimitCors");

            //app.UseHttpsRedirection().UseCors(builder =>
            //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            #endregion

            #region 使用Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "OilStationCoreAPI API V1.0");
            });
            #endregion

            #region 使用身份验证
            app.UseAuthentication();
            #endregion

            //app.UseJwtTokenAuth();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
