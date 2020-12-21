using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using System.Linq;

namespace OilStationCoreAPI.Services
{
    public class StaffServices : IStaffServices
    {
        private readonly OSMSContext _db;

        public StaffServices(OSMSContext db)
        {
            _db = db;
        }

        public Staff Login(LoginViewModel loginViewModel)
        {
            var model = _db.Staff.Where(u => u.No == loginViewModel.username && u.Password == loginViewModel.password).FirstOrDefault();
            return model;
        }
    }
}
