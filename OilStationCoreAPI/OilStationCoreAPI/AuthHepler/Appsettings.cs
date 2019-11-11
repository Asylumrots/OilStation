using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.AuthHepler
{
    public class Appsettings
    {
        static IConfiguration Configuration { get; set; }

        static Appsettings()
        {
            string Path = "appsettings.json";
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Add(new JsonConfigurationSource
                {
                    Path = Path,
                    Optional = false,
                    ReloadOnChange = true
                })
                .Build();// 这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
        }

        /// <summary>
        /// 封装要操作的字符串
        /// </summary>
        /// <param name="sections">节点</param>
        /// <returns>最后一个节点的值</returns>
        public static string app(params string[] sections)
        {
            try
            {
                var val = string.Empty;
                for (int i = 0; i < sections.Length; i++)
                {
                    val += sections[i] + ":";
                }
                return Configuration[val.TrimEnd(':')];
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}