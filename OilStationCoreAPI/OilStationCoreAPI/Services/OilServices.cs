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
    public class OilServices : IOilServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<OilOrderViewModel>> OilOrder_Get()
        {
            var user = db.AspNetUsers.Where(x => true);
            var list = db.OilMaterialOrder.Join(db.OilMaterialOrderDetail, m => m.Id, d => d.OrderId, (m, d) => new OilOrderViewModel
            {
                Id = m.Id.ToString(),
                No = m.No,
                ApplyPersonId = user.Where(x => x.Id == m.ApplyPersonId.ToString().ToLower()).FirstOrDefault().UserName,
                ApplyDate = Convert.ToDateTime(m.ApplyDate),
                Remark = m.Remark,
                OilSpec = d.OilSpec,
                Volume = Convert.ToDecimal(d.Volume),
                Surpuls = Convert.ToDecimal(d.Surplus),
                DayAvg = Convert.ToDecimal(d.DayAvg),
                NeedAmount = Convert.ToDecimal(d.NeedAmount)
            }).ToList();
            return new ResponseModel<List<OilOrderViewModel>>
            {
                code = (int)code.Success,
                data = list,
                message = ""//获取油料订单信息成功
            };
        }

        public ResponseModel<List<OilOrderViewModel>> OilOrder_CheckGet()
        {
            var user = db.AspNetUsers.Where(x => true);
            var list = db.OilMaterialOrder.Where(x => x.No == "0").Join(db.OilMaterialOrderDetail, m => m.Id, d => d.OrderId, (m, d) => new OilOrderViewModel
            {
                Id = m.Id.ToString(),
                No = m.No,
                ApplyPersonId = user.Where(x => x.Id == m.ApplyPersonId.ToString().ToLower()).FirstOrDefault().UserName,
                ApplyDate = Convert.ToDateTime(m.ApplyDate),
                Remark = m.Remark,
                OilSpec = d.OilSpec,
                Volume = Convert.ToDecimal(d.Volume),
                Surpuls = Convert.ToDecimal(d.Surplus),
                DayAvg = Convert.ToDecimal(d.DayAvg),
                NeedAmount = Convert.ToDecimal(d.NeedAmount)
            }).ToList();
            return new ResponseModel<List<OilOrderViewModel>>
            {
                code = (int)code.Success,
                data = list,
                message = ""//获取油料订单信息成功
            };
        }

        public ResponseModel<bool> OilOrder_Add(OilOrderViewModel model)
        {
            var user = db.AspNetUsers.Where(x => true);
            OilMaterialOrder o = new OilMaterialOrder();
            o.Id = Guid.NewGuid();
            o.No = "0";
            o.ApplyPersonId = new Guid(user.Where(x => x.UserName == model.ApplyPersonId).FirstOrDefault().Id);
            o.ApplyDate = model.ApplyDate;
            o.Remark = model.Remark;
            o.IsDel = false;
            o.CreateTime = DateTime.Now;
            o.UpdateTime = DateTime.Now;
            OilMaterialOrderDetail d = new OilMaterialOrderDetail();
            d.Id = Guid.NewGuid();
            d.OrderId = o.Id;
            d.OilSpec = model.OilSpec;
            d.Volume = model.Volume;
            d.Surplus = model.Surpuls;
            d.DayAvg = model.DayAvg;
            d.NeedAmount = model.NeedAmount;
            d.CreateTime = DateTime.Now;
            d.UpdateTime = DateTime.Now;
            db.OilMaterialOrder.Add(o);
            db.OilMaterialOrderDetail.Add(d);
            int num = db.SaveChanges();
            if (num >= 2)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加油料订单成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddOilOrderFail, data = false, message = "添加油料订单失败" };
        }

        public ResponseModel<bool> OilOrder_Check(CheckViewModel model)
        {
            var oilOrder = db.OilMaterialOrder.Where(x => x.Id.ToString().ToLower() == model.id).FirstOrDefault();
            oilOrder.No = model.CheckNo;
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "审核油料订单成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdateCheckOilOrderFail, data = false, message = "审核油料订单失败" };
        }

        public ResponseModel<bool> OilOrder_Delete(string id)
        {
            var oilOrder = db.OilMaterialOrder.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            var oilOrderDetail = db.OilMaterialOrderDetail.Where(x => x.OrderId.ToString().ToLower() == id).FirstOrDefault();
            db.OilMaterialOrder.Remove(oilOrder);
            db.OilMaterialOrderDetail.Remove(oilOrderDetail);
            int num = db.SaveChanges();
            if (num >= 2)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除油料订单成功" };
            }
            return new ResponseModel<bool> { code = (int)code.DeleteOilOrderFail, data = false, message = "删除油料订单失败" };
        }
    }
}
