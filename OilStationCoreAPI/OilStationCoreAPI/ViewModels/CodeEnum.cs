using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class CodeEnum
    {
        public enum code
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 200,

            /// <summary>
            /// 失败
            /// </summary>
            Fail = 400,

            /// <summary>
            /// 用户名或密码验证错误
            /// </summary>
            CheckError = 102,

            /// <summary>
            /// 用户名或密码错误
            /// </summary>
            LoginFaile = 101,
        }
    }
}
