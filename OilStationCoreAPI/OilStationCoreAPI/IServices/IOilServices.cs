using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IOilServices
    {
        ResponseModel<List<EntryViewModel>> OilOrder_Get();

        ResponseModel<bool> OilOrder_Add(EntryViewModel model);

        ResponseModel<bool> OilOrder_Delete(string id);
    }
}
