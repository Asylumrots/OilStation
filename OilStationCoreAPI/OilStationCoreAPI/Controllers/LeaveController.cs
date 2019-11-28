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
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveServices _leaveServices;

        public LeaveController(ILeaveServices leaveServices)
        {
            this._leaveServices = leaveServices;
        }

        [HttpGet]
        public ResponseModel<List<EntryViewModel>> Leave_Get()
        {
            return _leaveServices.Leave_Get();
        }

        [HttpPost]
        public ResponseModel<bool> Leave_Add([FromBody]EntryViewModel model)
        {
            return _leaveServices.Leave_Add(model);
        }

        [HttpDelete]
        public ResponseModel<bool> Leave_Delete(string id)
        {
            return _leaveServices.Leave_Delete(id);
        }
    }
}