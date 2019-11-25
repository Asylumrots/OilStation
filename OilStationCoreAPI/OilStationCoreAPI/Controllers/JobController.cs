using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.Services;
using OilStationCoreAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OilStationCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _jobServices;

        public JobController(IJobServices jobServices)
        {
            this._jobServices = jobServices;
        }

        [HttpGet]
        public ResponseModel<IEnumerable<Job>> Job_Get()
        {
            return _jobServices.Job_Get();
        }

        [HttpPut]
        public ResponseModel<bool> Job_Update([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Update(model);
        }

        [HttpDelete]
        public ResponseModel<bool> Job_Delete(string id)
        {
            return _jobServices.Job_Delete(id);
        }

        [HttpPost]
        public ResponseModel<bool> Job_Add([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Add(model);
        }
    }
}