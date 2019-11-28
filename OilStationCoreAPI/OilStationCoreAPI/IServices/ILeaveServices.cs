using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface ILeaveServices
    {
        ResponseModel<List<EntryViewModel>> Leave_Get();

        ResponseModel<bool> Leave_Add(EntryViewModel model);

        ResponseModel<bool> Leave_Delete(string id);
    }
}
