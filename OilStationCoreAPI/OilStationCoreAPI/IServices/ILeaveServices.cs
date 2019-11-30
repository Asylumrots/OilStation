using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface ILeaveServices
    {
        ResponseModel<List<LeaveViewModel>> Leave_Get();

        ResponseModel<List<LeaveViewModel>> Leave_CheckGet();

        ResponseModel<bool> Leave_Add(LeaveViewModel model);

        ResponseModel<bool> Leave_Check(CheckViewModel model);

        ResponseModel<bool> Leave_Delete(string id);
    }
}
