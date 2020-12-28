using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OilStationCoreAPI.IServices.LifeTime;

namespace OilStationCoreAPI.ConfigureSetup
{
    public static class AutoInjectionSetup
    {
        public static void AddAutoInjectionSetup(this IServiceCollection services, Assembly assembly)
        {
            //获取标记了IScopedDependency接口的接口
            var scopedInterfaceDependency = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IScopedDependency)))
                .SelectMany(t => t.GetInterfaces().Where(f => !f.FullName.Contains(".IScopedDependency")))
                .ToList();
            //获取标记了IScopedDependency接口的类
            var scopedTypeDependency = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IScopedDependency)))
                .ToList();
            //自动注入标记了IScopedDependency接口的 接口
            foreach (var interfaceName in scopedInterfaceDependency)
            {
                var type = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceName)).FirstOrDefault();
                if (type != null)
                    services.AddScoped(interfaceName, type);
            }

            //自动注入标记了IScopedDependency接口的 类
            foreach (var type in scopedTypeDependency)
            {
                services.AddScoped(type, type);
            }
        }
    }
}
