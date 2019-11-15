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
    public class AspNetRolesServices: IAspNetRolesServices
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
    }
}
