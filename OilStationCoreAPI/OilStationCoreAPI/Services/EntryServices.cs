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
    public class EntryServices : IEntryServices
    {
        private readonly OSMSContext _db;

        public EntryServices(OSMSContext db)
        {
            _db = db;
        }

        public ResponseModel<List<EntryViewModel>> Entry_Get()
        {
            //var list = _db.Entry.Where(x => true).Select(z => new List<EntryViewModel>() {
            //    new EntryViewModel()
            //    {
            //         WorkNumber=hggg(job.Id.ToString().ToLower()) ;
            //    }
            //});
            var list = _db.Entry.Where(x => true);
            var jobList = _db.Job.Where(x => true);
            List<EntryViewModel> reList = new List<EntryViewModel>();
            foreach (var item in list)
            {
                EntryViewModel entry = new EntryViewModel
                {
                    Id = item.Id.ToString(),
                    StaffName = item.StaffName,
                    Sex = item.Sex == true ? "男" : "女",
                    BirthDay = Convert.ToDateTime(item.BirthDay),
                    Address = item.Address,
                    Email = item.Email,
                    Tel = item.Tel,
                    ProbationarySalary = item.ProbationarySalary,
                    CorrectSalary = item.CorrectSalary,
                    EntryDate = Convert.ToDateTime(item.EntryDate),
                    CreateStaffeId = item.CreateStaffeId.ToString(),
                    CreateTime = Convert.ToDateTime(item.CreateTime),
                    WorkNumber = jobList
                        .FirstOrDefault(x => x.Id.ToString().ToLower() == item.WorkNumber.ToString().ToLower()).Name,
                    No = item.No,
                    Title = item.Title,
                    IsDel = item.IsDel
                };
                //foreach (var job in joblist)
                //{
                //    if (item.WorkNumber.ToString().ToLower() == job.Id.ToString().ToLower())
                //    {
                //        entry.WorkNumber = job.Name;
                //    }
                //}
                reList.Add(entry);
            }
            return new ResponseModel<List<EntryViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//获取入职信息成功
            };
        }

        public ResponseModel<List<EntryViewModel>> Entry_CheckGet()
        {
            var list = _db.Entry.Where(x => x.No == "0");
            var joblist = _db.Job.Where(x => true);
            List<EntryViewModel> reList = new List<EntryViewModel>();
            foreach (var item in list)
            {
                EntryViewModel entry = new EntryViewModel
                {
                    Id = item.Id.ToString(),
                    StaffName = item.StaffName,
                    Sex = item.Sex == true ? "男" : "女",
                    BirthDay = Convert.ToDateTime(item.BirthDay),
                    Address = item.Address,
                    Email = item.Email,
                    Tel = item.Tel,
                    ProbationarySalary = item.ProbationarySalary,
                    CorrectSalary = item.CorrectSalary,
                    EntryDate = Convert.ToDateTime(item.EntryDate),
                    CreateStaffeId = item.CreateStaffeId.ToString(),
                    CreateTime = Convert.ToDateTime(item.CreateTime),
                    WorkNumber = joblist.Where(x => x.Id.ToString().ToLower() == item.WorkNumber.ToString().ToLower())
                        .FirstOrDefault().Name
                };
                ;
                entry.No = item.No;
                entry.Title = item.Title;
                entry.IsDel = item.IsDel;
                reList.Add(entry);
            }
            return new ResponseModel<List<EntryViewModel>>
            {
                code = (int)code.Success,
                data = reList,
                message = ""//获取未审核入职信息成功
            };
        }

        public ResponseModel<bool> Entry_Add(EntryViewModel item)
        {
            Entry entry = new Entry
            {
                Id = Guid.NewGuid(),
                StaffName = item.StaffName,
                Sex = item.Sex == "男" ? true : false,
                BirthDay = Convert.ToDateTime(item.BirthDay),
                Address = item.Address,
                Email = item.Email,
                Tel = item.Tel,
                ProbationarySalary = item.ProbationarySalary,
                CorrectSalary = item.CorrectSalary,
                EntryDate = Convert.ToDateTime(item.EntryDate)
            };
            var user = _db.AspNetUsers.Where(x => x.UserName == item.CreateStaffeId).FirstOrDefault();
            entry.CreateStaffeId = new Guid(user.Id);
            entry.CreateTime = DateTime.Now;
            entry.UpdateTime = DateTime.Now;
            entry.WorkNumber = item.WorkNumber;
            //默认
            entry.No = "0";
            entry.IsDel = false;
            _db.Entry.Add(entry);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "添加入职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.AddEntryFail, data = false, message = "添加入职信息失败" };
        }

        public ResponseModel<bool> Entry_Delete(string id)
        {
            var entry = _db.Entry.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault();
            _db.Entry.Remove(entry);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "删除入职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.DeleteEntryFail, data = false, message = "删除入职信息失败" };
        }

        public ResponseModel<bool> Entry_Check(CheckViewModel model)
        {
            var entry = _db.Entry.Where(x => x.Id.ToString().ToLower() == model.Id).FirstOrDefault();
            entry.No = model.CheckNo;
            entry.Title = model.CheckTitle;
            _db.Entry.Update(entry);
            int num = _db.SaveChanges();
            if (num > 0)
            {
                return new ResponseModel<bool> { code = (int)code.Success, data = true, message = "审核入职信息成功" };
            }
            return new ResponseModel<bool> { code = (int)code.UpdateCheckEntryFail, data = false, message = "审核入职信息失败" };
        }



        //public string JobConvert(IQueryable<Job> joblist,string id)
        //{
        //    return joblist.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault().Name;
        //}
    }
}
