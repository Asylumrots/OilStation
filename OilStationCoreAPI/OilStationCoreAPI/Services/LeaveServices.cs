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
        private readonly OSMSContext _db;

        public LeaveServices(OSMSContext db)
        {
            _db = db;
        }

        public ResponseModel<List<LeaveViewModel>> Leave_Get()
        {
            var list = _db.LeaveOffice.Where(x => true);
            var joblist = _db.Job.Where(x => true);
            List<LeaveViewModel> reList = new List<LeaveViewModel>();
            foreach (var item in list)
            {
                LeaveViewModel leave = new LeaveViewModel
                {
                    Id = item.Id.ToString(),
                    StaffName = item.StaffName,
                    JobId = joblist.Where(x => x.Id.ToString().ToLower() == item.JobId.ToString().ToLower())
                        .FirstOrDefault().Name,
                    LeaveType = item.LeaveType == "0" ? "离职" : "辞退",
                    ApplyTime = Convert.ToDateTime(item.ApplyDate),
                    Reason = item.Reason,
                    No = item.No,
                    CreateTime = Convert.ToDateTime(item.CreateTime)
                };
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
            var list = _db.LeaveOffice.Where(x => x.No == "0");
            var joblist = _db.Job.Where(x => true);
            List<LeaveViewModel> reList = new List<LeaveViewModel>();
            foreach (var item in list)
            {
                LeaveViewModel leave = new LeaveViewModel
                {
                    Id = item.Id.ToString(),
                    StaffName = item.StaffName,
                    JobId = joblist.Where(x => x.Id.ToString().ToLower() == item.JobId.ToString().ToLower())
                        .FirstOrDefault().Name,
                    LeaveType = item.LeaveType,
                    ApplyTime = Convert.ToDateTime(item.ApplyDate),
                    Reason = item.Reason,
                    No = item.No,
                    CreateTime = Convert.ToDateTime(item.CreateTime)
                };
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
            LeaveOffice leave = new LeaveOffice
            {
                Id = Guid.NewGuid(),
                StaffName = model.StaffName,
                No = "0",
                JobId = new Guid(model.JobId),
                LeaveType = model.LeaveType == "离职" ? "0" : "1",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                ApplyDate = model.ApplyTime,
                Reason = model.Reason
            };
            _db.LeaveOffice.Add(leave);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddLeaveFail, data = false, message = "添加离职信息失败" };
        }

        public ResponseModel<bool> Leave_Check(CheckViewModel model)
        {
            var leave = _db.LeaveOffice.Where(x => x.Id.ToString().ToLower() == model.Id).FirstOrDefault();
            leave.No = model.CheckNo;
            _db.LeaveOffice.Update(leave);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "审核离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdaateCheckLeaveFail, data = false, message = "审核离职信息失败" };
        }

        public ResponseModel<bool> Leave_Delete(string id)
        {
            var leave = _db.LeaveOffice.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            _db.LeaveOffice.Remove(leave);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除离职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.DeleteLeaveFail, data = false, message = "删除离职信息失败" };
        }
    }
}
