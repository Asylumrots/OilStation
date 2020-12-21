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
    public class JobServices : IJobServices
    {
        private readonly OSMSContext _db;

        public JobServices(OSMSContext db)
        {
            _db = db;
        }

        public ResponseModel<IEnumerable<Job>> Job_Get()
        {
            var list = _db.Job.AsEnumerable();
            return new ResponseModel<IEnumerable<Job>>
            {
                code = (int)code.Success,
                data = list,
                message = ""//获取职位信息成功
            };
        }

        public ResponseModel<bool> Job_Update(JobViewModel model)
        {
            var job = _db.Job.Where(x => x.Id.ToString().ToLower() == model.id).FirstOrDefault();
            int num = 0;
            if (job != null)
            {
                job.Name = model.name;
                job.Code = model.code;
                num = _db.SaveChanges();
            }
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "修改职位信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdateJobFail, data = false, message = "修改职位信息失败" };
        }

        public ResponseModel<bool> Job_Delete(string id)
        {
            var job = _db.Job.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            int num = 0;
            if (job != null)
            {
                _db.Job.Remove(job);
                num = _db.SaveChanges();
            }
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除职位信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdateJobFail, data = false, message = "删除职位信息失败" };
        }

        public ResponseModel<bool> Job_Add(JobViewModel model)
        {
            Job job = new Job
            {
                Id = Guid.NewGuid(),
                Name = model.name,
                Code = model.code,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                IsDel = false
            };
            int num = 0;
            _db.Job.Add(job);
            num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加职位信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddJobFail, data = false, message = "添加职位信息失败" };
        }

    }
}
