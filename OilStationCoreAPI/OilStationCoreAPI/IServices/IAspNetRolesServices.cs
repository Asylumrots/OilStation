using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IAspNetRolesServices
    {
        ResponseModel<IEnumerable<RolesViewModel>> Roles_Get();

        ResponseModel<bool> Roles_Update(UserRolesViewModel model);

        ResponseModel<IEnumerable<string>> Claim_Get(string RoleId);

        ResponseModel<bool> Claim_Update(ClaimViewModel model);
    }
}
