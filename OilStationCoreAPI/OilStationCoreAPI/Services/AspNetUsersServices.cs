using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OilStationCoreAPI.IdentityModel;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OilStationCoreAPI.ViewModels.CodeEnum;

namespace OilStationCoreAPI.Services
{
    public class AspNetUsersServices : IAspNetUsersServices
    {
        //public AspNetUsersServices(UserManager<ApplicationUser> userManager)
        //{
        //    this._userManager = userManager;
        //}

        //private readonly UserManager<ApplicationUser> _userManager;
        OSMSContext db = new OSMSContext();
        //ApplicationDbContext adb = new ApplicationDbContext();

        public ResponseModel<IEnumerable<UserAndRoleViewModel>> UserRole_Get()
        {
            List<UserAndRoleViewModel> reList = new List<UserAndRoleViewModel>();
            var list = db.AspNetUsers.Where(x => true);
            try
            {
                foreach (var item in list)
                {
                    UserAndRoleViewModel userRoleViewModel = new UserAndRoleViewModel();
                    var s = db.AspNetUserRoles.Where(x => x.UserId == item.Id).FirstOrDefault();
                    string roleName = null;
                    if (s != null)
                        roleName = db.AspNetRoles.Where(x => x.Id == s.RoleId).FirstOrDefault().Name;
                    else
                        roleName = "暂无";

                    userRoleViewModel.Id = item.Id;
                    userRoleViewModel.RoleName = roleName;
                    userRoleViewModel.UserName = item.UserName;
                    userRoleViewModel.PhoneNumber = item.PhoneNumber;
                    userRoleViewModel.UserSex = item.UserSex == "1" ? "男" : "女";
                    userRoleViewModel.PhoneNumber = item.PhoneNumber;
                    userRoleViewModel.Email = item.Email;
                    userRoleViewModel.BirthDay = item.BirthDay;
                    userRoleViewModel.Address = item.Address;

                    reList.Add(userRoleViewModel);
                }
                reList.AsEnumerable();
            }
            catch (Exception e)
            {
                return new ResponseModel<IEnumerable<UserAndRoleViewModel>>
                {
                    code = (int)code.GetUserRoleInfoFail,
                    data = null,
                    message = "用户角色信息获取失败，" + e.Message
                };
            }
            return new ResponseModel<IEnumerable<UserAndRoleViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = "用户角色信息获取成功"
            };
        }

        public ResponseModel<bool> UserInfo_Update(UserInfoViewModel model)
        {
            var userInfo = db.AspNetUsers.Where(x => x.Id == model.id).FirstOrDefault();
            userInfo.UserName = model.userName;
            userInfo.UserSex = model.userSex == "男" ? "1" : "0";
            userInfo.PhoneNumber = model.phoneNumber;
            userInfo.Email = model.email;
            userInfo.Address = model.address;
            userInfo.BirthDay = model.birthday;
            db.AspNetUsers.Update(userInfo);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool>
                {
                    code = (int)code.Success,
                    data = true,
                    message = "修改用户信息成功！"
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    code = (int)code.UpdateUserInfoFail,
                    data = false,
                    message = "修改用户信息失败！"
                };
            }
        }

        public ResponseModel<bool> UserInfo_Delete(string id)
        {
            var userInfo = db.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
            db.AspNetUsers.Remove(userInfo);
            int num = db.SaveChanges();
            return new ResponseModel<bool>
            {
                code = (int)code.Success,
                data = false,
                message = "删除用户成功"
            };
        }
    }
}
