using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IOilServices
    {
        ResponseModel<List<OilOrderViewModel>> OilOrder_Get();

        ResponseModel<List<OilOrderViewModel>> OilOrder_CheckGet();

        ResponseModel<bool> OilOrder_Add(OilOrderViewModel model);

        ResponseModel<bool> OilOrder_Check(CheckViewModel model);

        ResponseModel<bool> OilOrder_Delete(string id);
    }
}
