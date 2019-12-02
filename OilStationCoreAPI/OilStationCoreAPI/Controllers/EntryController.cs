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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryServices _entryServices;

        public EntryController(IEntryServices entryServices)
        {
            this._entryServices = entryServices;
        }

        [HttpGet]
        [Authorize(Policy = "Entry_Get")]
        public ResponseModel<List<EntryViewModel>> Entry_Get()
        {
            return _entryServices.Entry_Get();
        }

        [HttpGet]
        [Authorize(Policy = "Entry_CheckGet")]
        public ResponseModel<List<EntryViewModel>> Entry_CheckGet()
        {
            return _entryServices.Entry_CheckGet();
        }

        [HttpPost]
        [Authorize(Policy = "Entry_Add")]
        public ResponseModel<bool> Entry_Add([FromBody]EntryViewModel model)
        {
            return _entryServices.Entry_Add(model);
        }

        [HttpPost]
        [Authorize(Policy = "Entry_Check")]
        public ResponseModel<bool> Entry_Check([FromBody]CheckViewModel model)
        {
            return _entryServices.Entry_Check(model);
        }

        [HttpPost]
        [Authorize(Policy = "Entry_Delete")]
        public ResponseModel<bool> Entry_Delete(string id)
        {
            return _entryServices.Entry_Delete(id);
        }
    }
}