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
    /// <summary>
    /// 职位信息控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _jobServices;

        public JobController(IJobServices jobServices)
        {
            this._jobServices = jobServices;
        }

        /// <summary>
        /// 获取职位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Job_Get")]
        public ResponseModel<IEnumerable<Job>> Job_Get()
        {
            return _jobServices.Job_Get();
        }

        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Job_Add")]
        public ResponseModel<bool> Job_Add([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Add(model);
        }

        /// <summary>
        /// 更新职位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Job_Update")]
        public ResponseModel<bool> Job_Update([FromBody]JobViewModel model)
        {
            return _jobServices.Job_Update(model);
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Job_Delete")]
        public ResponseModel<bool> Job_Delete(string id)
        {
            return _jobServices.Job_Delete(id);
        }

        
    }
}