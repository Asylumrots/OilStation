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

        public ResponseModel<IEnumerable<UserRoleViewModel>> UserRole_Get()
        {
            List<UserRoleViewModel> reList = new List<UserRoleViewModel>();
            var list = db.AspNetUsers.Where(x => true);
            foreach (var item in list)
            {
                UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
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
            return new ResponseModel<IEnumerable<UserRoleViewModel>> { code = (int)code.Success, data = reList, message = "用户角色信息获取成功" };
        }
    }
}
