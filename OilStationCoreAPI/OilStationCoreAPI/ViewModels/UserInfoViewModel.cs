using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class UserInfoViewModel
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string userSex { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
    }
}
