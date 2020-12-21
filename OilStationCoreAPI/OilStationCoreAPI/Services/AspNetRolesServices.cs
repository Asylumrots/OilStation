using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static OilStationCoreAPI.ViewModels.CodeEnum;

namespace OilStationCoreAPI.Services
{
    public class AspNetRolesServices : IAspNetRolesServices
    {
        private readonly OSMSContext _db;

        public AspNetRolesServices(OSMSContext db)
        {
            _db = db;
        }

        public ResponseModel<IEnumerable<RolesViewModel>> Roles_Get()
        {
            var list = _db.AspNetRoles.Where(x => true);
            List<RolesViewModel> reList = new List<RolesViewModel>();
            try
            {
                foreach (var item in list)
                {
                    RolesViewModel model = new RolesViewModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                    reList.Add(model);
                }
                reList.AsEnumerable();
            }
            catch (Exception e)
            {
                return new ResponseModel<IEnumerable<RolesViewModel>>
                {
                    code = (int)code.GetRoleFail,
                    data = null,
                    message = "角色信息获取失败," + e.Message,
                };
            }
            return new ResponseModel<IEnumerable<RolesViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//角色信息获取成功
            };
        }

        public ResponseModel<bool> Roles_Update(UserRolesViewModel model)
        {
            var UserRole = _db.AspNetUserRoles.Where(x => x.UserId == model.UserId).FirstOrDefault();
            int num = 0;
            if (UserRole != null)
            {
                _db.AspNetUserRoles.Remove(UserRole);
                num = _db.SaveChanges();
                UserRole.RoleId = model.RoleId;
                _db.AspNetUserRoles.Add(UserRole);
            }
            else
            {
                AspNetUserRoles aspNetUserRoles = new AspNetUserRoles
                {
                    UserId = model.UserId,
                    RoleId = model.RoleId
                };
                _db.AspNetUserRoles.Add(aspNetUserRoles);
            }
            num += _db.SaveChanges();
            if (num > 0)
                return new ResponseModel<bool>
                {
                    code = (int)code.Success,
                    data = true,
                    message = "修改用户角色成功！"
                };
            else
                return new ResponseModel<bool>
                {
                    code = (int)code.UpdateRoleFail,
                    data = false,
                    message = "修改用户角色失败！"
                };
        }

        public ResponseModel<IEnumerable<string>> Claim_Get(string RoleId)
        {
            var list = _db.AspNetRoleClaims.Where(x => x.RoleId == RoleId);
            List<string> reList = new List<string>();
            try
            {
                foreach (var item in list)
                {
                    string str = item.ClaimType + "_" + item.ClaimValue;
                    reList.Add(str);
                }
                reList.AsEnumerable();
            }
            catch (Exception e)
            {
                return new ResponseModel<IEnumerable<string>>
                {
                    code = (int)code.GetClaimFail,
                    data = null,
                    message = "声明信息获取失败，" + e.Message
                };
            }
            return new ResponseModel<IEnumerable<string>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//声明信息获取成功
            };
        }

        public ResponseModel<bool> Claim_Update(ClaimViewModel model)
        {
            var flag = _db.AspNetRoleClaims.Where(x => x.RoleId == model.RoleId);
            foreach (var item in flag)
            {
                _db.AspNetRoleClaims.Remove(item);
            }
            List<string> list = model.ClaimList;
            foreach (var item in list)
            {
                var s = item.Split("_");
                if (s.Length == 1)
                {
                    continue;
                }

                AspNetRoleClaims roleClaims = new AspNetRoleClaims
                {
                    RoleId = model.RoleId,
                    ClaimType = s[0],
                    ClaimValue = s[1]
                };
                _db.AspNetRoleClaims.Add(roleClaims);
            }
            int n = _db.SaveChanges();
            if (n > 0)
            {
                return new ResponseModel<bool>
                {
                    code = (int)code.Success,
                    data = true,
                    message = "修改声明成功"
                };
            }
            return new ResponseModel<bool>
            {
                code = (int)code.UpdateClaimFail,
                data = false,
                message = "修改声明失败"
            };
        }
    }
}
