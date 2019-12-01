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
    public class LeaveServices : ILeaveServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<LeaveViewModel>> Leave_Get()
        {
            var list = db.LeaveOffice.Where(x => true);
            var joblist = db.Job.Where(x => true);
            List<LeaveViewModel> reList = new List<LeaveViewModel>();
            foreach (var item in list)
            {
                LeaveViewModel leave = new LeaveViewModel();
                leave.Id = item.Id.ToString();
                leave.StaffName = item.StaffName;
                leave.JobId = joblist.Where(x => x.Id.ToString().ToLower() == item.JobId.ToString().ToLower()).FirstOrDefault().Name;
                leave.LeaveType = item.LeaveType == "0" ? "离职" : "辞退";
                leave.ApplyTime = Convert.ToDateTime(item.ApplyDate);
                leave.Reason = item.Reason;
                leave.No = item.No;
                leave.CreateTime = Convert.ToDateTime(item.CreateTime);
                reList.Add(leave);
            }
            return new ResponseModel<List<LeaveViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//获取离职信息成功
            };
        }

        public ResponseModel<List<LeaveViewModel>> Leave_CheckGet()
        {
            var list = db.LeaveOffice.Where(x => x.No == "0");
            var joblist = db.Job.Where(x => true);
            List<LeaveViewModel> reList = new List<LeaveViewModel>();
            foreach (var item in list)
            {
                LeaveViewModel leave = new LeaveViewModel();
                leave.Id = item.Id.ToString();
                leave.StaffName = item.StaffName;
                leave.JobId = joblist.Where(x => x.Id.ToString().ToLower() == item.JobId.ToString().ToLower()).FirstOrDefault().Name;
                leave.LeaveType = item.LeaveType;
                leave.ApplyTime = Convert.ToDateTime(item.ApplyDate);
                leave.Reason = item.Reason;
                leave.No = item.No;
                leave.CreateTime = Convert.ToDateTime(item.CreateTime);
                reList.Add(leave);
            }
            return new ResponseModel<List<LeaveViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//获取未审核离职信息成功
            };
        }

        public ResponseModel<bool> Leave_Add(LeaveViewModel model)
        {
            LeaveOffice leave = new LeaveOffice();
            leave.Id = Guid.NewGuid();
            leave.StaffName = model.StaffName;
            leave.No = "0";
            leave.JobId = new Guid(model.JobId);
            leave.LeaveType = model.LeaveType == "离职" ? "0" : "1";
            leave.CreateTime = DateTime.Now;
            leave.UpdateTime = DateTime.Now;
            leave.ApplyDate = model.ApplyTime;
            leave.Reason = model.Reason;
            db.LeaveOffice.Add(leave);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddLeaveFail, data = false, message = "添加离职信息失败" };
        }

        public ResponseModel<bool> Leave_Check(CheckViewModel model)
        {
            var leave = db.LeaveOffice.Where(x => x.Id.ToString().ToLower() == model.id).FirstOrDefault();
            leave.No = model.CheckNo;
            db.LeaveOffice.Update(leave);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "审核离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdaateCheckLeaveFail, data = false, message = "审核离职信息失败" };
        }

        public ResponseModel<bool> Leave_Delete(string id)
        {
            var leave = db.LeaveOffice.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            db.LeaveOffice.Remove(leave);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.DeleteLeaveFail, data = false, message = "删除离职信息失败" };
        }
    }
}
