using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IdentityModel
{
    public class ApplicationUser: IdentityUser  //重写identityUser 并注册到服务中
    {
        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string JobId { get; set; }
        public string OrgId { get; set; }
        public int IsHSEGroup { get; set; }
    }
}
