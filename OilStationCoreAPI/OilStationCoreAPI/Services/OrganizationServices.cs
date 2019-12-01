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
    public class OrganizationServices : IOrganizationServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<OrganizationViewModel>> Organ_Get()
        {
            var leve0 = db.OrganizationStructure.Where(x => x.Leve == 0).FirstOrDefault();
            OrganizationViewModel model = new OrganizationViewModel();
            List<OrganizationViewModel> list = get(leve0.Id.ToString());
            model.id = leve0.Id.ToString();
            model.label = leve0.Name;
            model.code = leve0.Code;
            model.children = list;
            List<OrganizationViewModel> relist = new List<OrganizationViewModel>();
            relist.Add(model);
            return new ResponseModel<List<OrganizationViewModel>>
            {
                code = (int)code.Success,
                data = relist,
                message = ""//获取站点信息成功
            };
        }

        public List<OrganizationViewModel> get(string paid)
        {
            var chList = db.OrganizationStructure.Where(x => x.ParentId.ToString().ToLower() == paid);
            List<OrganizationViewModel> list = new List<OrganizationViewModel>();
            foreach (var item in chList)
            {
                list.Add(new OrganizationViewModel { id = item.Id.ToString(), label = item.Name, code = item.Code, children = get(item.Id.ToString()) });
            }
            return list;
        }

        public ResponseModel<bool> Organ_Add(OrganizationAddViewModel model)
        {
            var parent = db.OrganizationStructure.Where(x => x.ParentId.ToString().ToLower() == model.id).FirstOrDefault();
            OrganizationStructure organization = new OrganizationStructure();
            organization.Id = Guid.NewGuid();
            organization.Name = model.name;
            organization.Code = model.code;
            organization.Leve = parent.Leve + 1;
            organization.ParentId = parent.Id;
            organization.CreateTime = DateTime.Now;
            organization.UpdateTime = DateTime.Now;
            organization.IsDel = false;
            db.OrganizationStructure.Add(organization);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加机构成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddOrganizationFail, data = false, message = "添加机构失败" };
        }

        public ResponseModel<bool> Organ_Update(OrganizationAddViewModel model)
        {
            var organization = db.OrganizationStructure.Where(x => x.Id.ToString().ToLower() == model.id).FirstOrDefault();
            organization.Name = model.name;
            organization.Code = model.code;
            db.OrganizationStructure.Update(organization);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "修改机构信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdateOrganizationFail, data = false, message = "修改机构信息失败" };
        }

        public ResponseModel<bool> Organ_Delete(string id)
        {
            var organization = db.OrganizationStructure.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            db.OrganizationStructure.Remove(organization);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除机构成功" };
            }
            return new ResponseModel<bool> { code = (int)code.DeleteOrganizationFail, data = false, message = "删除机构失败" };
        }
    }
}
