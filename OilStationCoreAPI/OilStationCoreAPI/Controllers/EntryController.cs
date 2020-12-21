using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.Services;
using OilStationCoreAPI.ViewModels;
namespace OilStationCoreAPI.Controllers
{
    /// <summary>
    /// 入职信息控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryServices _entryServices;

        public EntryController(IEntryServices entryServices)
        {
            _entryServices = entryServices;
        }

        /// <summary>
        /// 获取入职信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Entry_Get")]
        //[SwaggerOperation("GetAll")]
        public ResponseModel<List<EntryViewModel>> Entry_Get()
        {
            return _entryServices.Entry_Get();
        }

        /// <summary>
        /// 获取未审核入职信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Entry_CheckGet")]
        public ResponseModel<List<EntryViewModel>> Entry_CheckGet()
        {
            return _entryServices.Entry_CheckGet();
        }

        /// <summary>
        /// 添加入职信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Entry_Add")]
        public ResponseModel<bool> Entry_Add([FromBody]EntryViewModel model)
        {
            return _entryServices.Entry_Add(model);
        }

        /// <summary>
        /// 审核入职信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Entry_Check")]
        public ResponseModel<bool> Entry_Check([FromBody]CheckViewModel model)
        {
            return _entryServices.Entry_Check(model);
        }

        /// <summary>
        /// 删除入职信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Entry_Delete")]
        public ResponseModel<bool> Entry_Delete(string id)
        {
            return _entryServices.Entry_Delete(id);
        }
    }
}