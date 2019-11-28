using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ResponseModel<List<EntryViewModel>> OilOrder_Get()
        {
            return _oilServices.OilOrder_Get();
        }

        [HttpPost]
        public ResponseModel<bool> OilOrder_Add([FromBody]EntryViewModel model)
        {
            return _oilServices.OilOrder_Add(model);
        }

        [HttpDelete]
        public ResponseModel<bool> OilOrder_Delete(string id)
        {
            return _oilServices.OilOrder_Delete(id);
        }
    }
}