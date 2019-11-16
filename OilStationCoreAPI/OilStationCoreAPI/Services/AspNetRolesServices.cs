using Microsoft.AspNetCore.Identity;
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
    public class AspNetRolesServices : IAspNetRolesServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<IEnumerable<RolesViewModel>> Roles_Get()
        {
            var list = db.AspNetRoles.Where(x => true);
            List<RolesViewModel> reList = new List<RolesViewModel>();
            foreach (var item in list)
            {
                RolesViewModel model = new RolesViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                reList.Add(model);
            }
            reList.AsEnumerable();
            return new ResponseModel<IEnumerable<RolesViewModel>> { code = (int)code.Success, data = reList, message = "角色信息获取成功" };
        }

        public ResponseModel<bool> Roles_Update(UserRolesViewModel model)
        {
            var UserRole = db.AspNetUserRoles.Where(x => x.UserId == model.UserId).FirstOrDefault();
            int num=0;
            if (UserRole != null)
            {
                db.AspNetUserRoles.Remove(UserRole);
                num = db.SaveChanges();
                UserRole.RoleId = model.RoleId;
            }
            db.AspNetUserRoles.Add(UserRole);
            num += db.SaveChanges();
            if (num == 2)
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "修改用户角色成功！" };
            else
                return new ResponseModel<bool> { code = (int)code.UpdateRole, data = false, message = "修改用户角色失败！" };
        }
    }
}
