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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationServices _organizationServices;

        public OrganizationController(IOrganizationServices organizationServices)
        {
            this._organizationServices = organizationServices;
        }

        [HttpGet]
        [Authorize(Policy = "Organization_Get")]
        public ResponseModel<List<OrganizationViewModel>> Organization_Get()
        {
            return _organizationServices.Organ_Get();
        }

        [HttpPost]
        [Authorize(Policy = "Organization_Add")]
        public ResponseModel<bool> Organization_Add([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Add(model);
        }

        [HttpPost]
        [Authorize(Policy = "Organization_Update")]
        public ResponseModel<bool> Organization_Update([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Update(model);
        }

        [HttpPost]
        [Authorize(Policy = "Organization_Delete")]
        public ResponseModel<bool> Organization_Delete(string id)
        {
            return _organizationServices.Organ_Delete(id);
        }
    }
}