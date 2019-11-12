using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IStaffServices
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        Staff Login(LoginViewModel loginViewModel);
    }
}
