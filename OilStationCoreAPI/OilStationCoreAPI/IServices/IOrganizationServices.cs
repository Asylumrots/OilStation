using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IOrganizationServices
    {
        ResponseModel<List<OrganizationViewModel>> Organ_Get();

        ResponseModel<bool> Organ_Add(OrganizationAddViewModel model);

        ResponseModel<bool> Organ_Update(OrganizationAddViewModel model);

        ResponseModel<bool> Organ_Delete(string id);
    }
}
