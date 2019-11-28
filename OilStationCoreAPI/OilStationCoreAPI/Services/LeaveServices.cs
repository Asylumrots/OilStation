using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.Services
{
    public class LeaveServices : ILeaveServices
    {
        OSMSContext db = new OSMSContext();

        public ResponseModel<List<EntryViewModel>> Leave_Get()
        {
            return null;
        }

        public ResponseModel<bool> Leave_Add(EntryViewModel model)
        {
            return null;
        }

        public ResponseModel<bool> Leave_Delete(string id)
        {
            return null;
        }
    }
}
