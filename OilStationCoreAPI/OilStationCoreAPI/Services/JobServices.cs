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
        OSMSContext db = new OSMSContext();

        public ResponseModel<IEnumerable<Job>> Job_Get()
        {
            var list = db.Job.AsEnumerable();
            return new ResponseModel<IEnumerable<Job>> { code = (int)code.Success, data = list, message = "获取职位信息成功" };
        }
    }
}
