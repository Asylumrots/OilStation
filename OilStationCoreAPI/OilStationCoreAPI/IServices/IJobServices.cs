using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IJobServices
    {
        ResponseModel<IEnumerable<Job>> Job_Get();

        ResponseModel<bool> Job_Update(JobViewModel model);

        ResponseModel<bool> Job_Delete(string id);

        ResponseModel<bool> Job_Add(JobViewModel model);

    }
}
