using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.IServices
{
    public interface IEntryServices
    {
        ResponseModel<List<EntryViewModel>> Entry_Get();

        ResponseModel<bool> Entry_Add(EntryViewModel model);

        ResponseModel<bool> Entry_Delete(string id);
    }
}
