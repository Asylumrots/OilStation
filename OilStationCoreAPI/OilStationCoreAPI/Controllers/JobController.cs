using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.Services;
using OilStationCoreAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "Job_Get")]
        public ResponseModel<IEnumerable<Job>> Job_Get()
        {
            return _jobServices.Job_Get();
        }

        [HttpPost]
        [Authorize(Policy = "Job_Add")]
        public ResponseModel<bool> Job_Add([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Add(model);
        }

        [HttpPut]
        [Authorize(Policy = "Job_Update")]
        public ResponseModel<bool> Job_Update([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Update(model);
        }

        [HttpDelete]
        [Authorize(Policy = "Job_Delete")]
        public ResponseModel<bool> Job_Delete(string id)
        {
            return _jobServices.Job_Delete(id);
        }

        
    }
}