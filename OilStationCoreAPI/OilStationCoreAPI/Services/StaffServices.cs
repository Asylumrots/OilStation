using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.Services
{
    public class StaffServices : IStaffServices
    {
        OSMSContext db = new OSMSContext();

        public Staff Login(LoginViewModel loginViewModel)
        {
            var model = db.Staff.Where(u => u.No == loginViewModel.username && u.Password == loginViewModel.password).FirstOrDefault();
            return model;
        }
    }
}
