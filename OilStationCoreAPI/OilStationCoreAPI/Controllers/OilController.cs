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
    /// 油料信息控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OilController : ControllerBase
    {
        private readonly IOilServices _oilServices;

        public OilController(IOilServices oilServices)
        {
            this._oilServices = oilServices;
        }

        /// <summary>
        /// 获取油料申请信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "OilOrder_Get")]
        public ResponseModel<List<OilOrderViewModel>> OilOrder_Get()
        {
            return _oilServices.OilOrder_Get();
        }

        /// <summary>
        /// 获取未审核油料申请信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "OilOrder_CheckGet")]
        public ResponseModel<List<OilOrderViewModel>> OilOrder_CheckGet()
        {
            return _oilServices.OilOrder_CheckGet();
        }

        /// <summary>
        /// 添加油料申请信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "OilOrder_Add")]
        public ResponseModel<bool> OilOrder_Add([FromBody]OilOrderViewModel model)
        {
            return _oilServices.OilOrder_Add(model);
        }

        /// <summary>
        /// 审核油料申请信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "OilOrder_Check")]
        public ResponseModel<bool> OilOrder_Check([FromBody]CheckViewModel model)
        {
            return _oilServices.OilOrder_Check(model);
        }

        /// <summary>
        /// 删除油料申请信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "OilOrder_Delete")]
        public ResponseModel<bool> OilOrder_Delete(string id)
        {
            return _oilServices.OilOrder_Delete(id);
        }
    }
}