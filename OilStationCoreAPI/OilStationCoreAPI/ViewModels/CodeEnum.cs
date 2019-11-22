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

            /// <summary>
            /// 用户角色信息获取失败
            /// </summary>
            GetUserRoleInfoFail = 601,

            /// <summary>
            /// 角色信息获取失败
            /// </summary>
            GetRoleFail = 602,

            /// <summary>
            /// 声明信息获取失败
            /// </summary>
            GetClaimFail = 603,

            /// <summary>
            /// 修改用户角色失败
            /// </summary>
            UpdateRoleFail = 701,

            /// <summary>
            /// 修改声明失败
            /// </summary>
            UpdateClaimFail = 702,

            /// <summary>
            /// 修改用户信息失败
            /// </summary>
            UpdateUserInfoFail = 703,

        }
    }
}
