using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace OilStationCoreAPI.ConfigureSetup
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Contact = new Contact
                    {
                        Name = "Asylumrots",
                        Email = "zw@zhangfive.cn",
                        Url = "http://zhangfive.cn"
                    },
                    Description = "A front-background project build by ASP.NET Core 2.2 and Vue",
                    Title = "OilStationCoreAPI",
                    Version = "v1",
                });
                //添加读取注释服务 //需要先设置启动生成xml文件
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "OilStationCoreAPI.xml");//修改名称
                c.IncludeXmlComments(xmlPath, true);

                #region Token绑定到ConfigureServices
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "OilStationCoreAPI", new string[] { } }, };
                c.AddSecurityRequirement(security);
                //方案名称“Blog.Core”可自定义，上下一致即可
                c.AddSecurityDefinition("OilStationCoreAPI", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });

                c.OrderActionsBy(o => o.GroupName); //显示排序具体可看属性
                #endregion
            });
        }
    }
}
