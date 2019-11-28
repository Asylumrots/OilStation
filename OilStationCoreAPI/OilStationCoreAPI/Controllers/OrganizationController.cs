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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationServices _organizationServices;

        public OrganizationController(IOrganizationServices organizationServices)
        {
            this._organizationServices = organizationServices;
        }

        [HttpGet]
        public ResponseModel<List<OrganizationViewModel>> Organization_Get()
        {
            return _organizationServices.Organ_Get();
        }

        [HttpPost]
        public ResponseModel<bool> Organization_Add([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Add(model);
        }

        [HttpPut]
        public ResponseModel<bool> Organization_Update([FromBody]OrganizationAddViewModel model)
        {
            return _organizationServices.Organ_Update(model);
        }

        [HttpDelete]
        public ResponseModel<bool> Organization_Delete(string id)
        {
            return _organizationServices.Organ_Delete(id);
        }
    }
}