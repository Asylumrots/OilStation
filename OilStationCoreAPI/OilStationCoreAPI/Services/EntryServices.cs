using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.Services
{
    public class EntryServices : IEntryServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<EntryViewModel>> Entry_Get()
        {
            return null;
        }

        public ResponseModel<bool> Entry_Add(EntryViewModel model)
        {
            return null;
        }

        public ResponseModel<bool> Entry_Delete(string id)
        {
            return null;
        }
    }
}
