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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OilController : ControllerBase
    {
        private readonly IOilServices _oilServices;

        public OilController(IOilServices oilServices)
        {
            this._oilServices = oilServices;
        }

        [HttpGet]
        [Authorize(Policy = "OilOrder_Get")]
        public ResponseModel<List<OilOrderViewModel>> OilOrder_Get()
        {
            return _oilServices.OilOrder_Get();
        }

        [HttpGet]
        [Authorize(Policy = "OilOrder_CheckGet")]
        public ResponseModel<List<OilOrderViewModel>> OilOrder_CheckGet()
        {
            return _oilServices.OilOrder_CheckGet();
        }

        [HttpPost]
        [Authorize(Policy = "OilOrder_Add")]
        public ResponseModel<bool> OilOrder_Add([FromBody]OilOrderViewModel model)
        {
            return _oilServices.OilOrder_Add(model);
        }

        [HttpPut]
        [Authorize(Policy = "OilOrder_Check")]
        public ResponseModel<bool> OilOrder_Check([FromBody]CheckViewModel model)
        {
            return _oilServices.OilOrder_Check(model);
        }

        [HttpDelete]
        [Authorize(Policy = "OilOrder_Delete")]
        public ResponseModel<bool> OilOrder_Delete(string id)
        {
            return _oilServices.OilOrder_Delete(id);
        }
    }
}