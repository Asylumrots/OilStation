using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.ViewModels;

namespace OilStationCoreAPI.Controllers
{
    /// <summary>
    /// 组织信息控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationServices _organizationServices;

        public OrganizationController(IOrganizationServices organizationServices)
        {
            _organizationServices = organizationServices;
        }

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Organization_Get")]
        public ResponseModel<List<OrganizationViewModel>> Organization_Get()
        {
            return _organizationServices.Organ_Get();
        }

        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Organization_Add")]
        public ResponseModel<bool> Organization_Add([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Add(model);
        }

        /// <summary>
        /// 更新组织信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Organization_Update")]
        public ResponseModel<bool> Organization_Update([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Update(model);
        }

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Organization_Delete")]
        public ResponseModel<bool> Organization_Delete(string id)
        {
            return _organizationServices.Organ_Delete(id);
        }
    }
}