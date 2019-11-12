using OilStationCoreAPI.Model;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IUserServices
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        Staff Login(LoginViewModel loginViewModel);
    }
}
