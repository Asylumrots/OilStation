using System;
using Microsoft.Extensions.DependencyInjection;

namespace OilStationCoreAPI.ConfigureSetup
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //跨域方法，声明策略,下边app中配置
            services.AddCors(c =>
            {
                //注意正式环境不要使用这种全开放的处理
                c.AddPolicy("AllowCors", policy =>
                {
                    policy
                        .AllowAnyOrigin()//允许任何源
                        .AllowAnyMethod()//允许任何方式
                        .AllowAnyHeader()//允许任何头
                        .AllowCredentials();//允许cookie
                });
                c.AddPolicy("LimitCors", policy =>
                {
                    // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                    // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
                    policy
                        .WithOrigins("http://47.102.210.25:60", "http://47.102.210.25:20", "http://172.17.25.167:60", "http://172.17.25.167:20", "http://localhost:9528")
                        .AllowAnyHeader()//Ensures that the policy allows any header.
                        .AllowAnyMethod().AllowCredentials();
                    //.WithExposedHeaders("Token-Expired");
                });
            });

            //services.AddCors(options => options.AddPolicy("AllowCors", builder => builder.AllowAnyOrigin().AllowAnyMethod()));
        }
    }
}
