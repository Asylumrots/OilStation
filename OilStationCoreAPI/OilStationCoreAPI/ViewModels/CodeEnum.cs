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

            /// <summary>
            /// 修改职位信息失败
            /// </summary>
            UpdateJobFail = 704,

            /// <summary>
            /// 修改机构信息失败
            /// </summary>
            UpdateOrganizationFail=705,

            /// <summary>
            /// 审核入职信息失败
            /// </summary>
            UpdateCheckEntryFail=706,

            /// <summary>
            /// 审核离职信息失败
            /// </summary>
            UpdaateCheckLeaveFail=707,

            /// <summary>
            /// 审核油料订单失败
            /// </summary>
            UpdateCheckOilOrderFail=708,

            /// <summary>
            /// 删除用户失败
            /// </summary>
            DeleteUserFail=801,
            
            /// <summary>
            /// 删除职位失败
            /// </summary>
            DeleteJobFail=802,

            /// <summary>
            /// 删除机构失败
            /// </summary>
            DeleteOrganizationFail=803,

            /// <summary>
            /// 删除入职信息失败
            /// </summary>
            DeleteEntryFail=804,

            /// <summary>
            /// 删除离职信息失败
            /// </summary>
            DeleteLeaveFail=805,

            /// <summary>
            /// 删除油料订单失败
            /// </summary>
            DeleteOilOrderFail=806,

            /// <summary>
            /// 添加职位失败
            /// </summary>
            AddJobFail=901,

            /// <summary>
            /// 添加机构失败
            /// </summary>
            AddOrganizationFail=902,

            /// <summary>
            /// 添加入职信息失败
            /// </summary>
            AddEntryFail=903,

            /// <summary>
            /// 添加离职信息失败
            /// </summary>
            AddLeaveFail=904,

            /// <summary>
            /// 添加油料订单失败
            /// </summary>
            AddOilOrderFail=905,

            /// <summary>
            /// Token过期
            /// </summary>
            TokenExpired=1002,

            /// <summary>
            /// Token错误
            /// </summary>
            TokenError=1001,
        }
    }
}
