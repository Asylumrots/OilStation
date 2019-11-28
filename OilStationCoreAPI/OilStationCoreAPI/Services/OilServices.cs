using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.Services
{
    public class OilServices : IOilServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<EntryViewModel>> OilOrder_Get()
        {
            return null;
        }

        public ResponseModel<bool> OilOrder_Add(EntryViewModel model)
        {
            return null;
        }

        public ResponseModel<bool> OilOrder_Delete(string id)
        {
            return null;
        }
    }
}
