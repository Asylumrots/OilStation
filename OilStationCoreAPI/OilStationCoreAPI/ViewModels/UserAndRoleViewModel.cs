using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class UserAndRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserSex { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }

        public string RoleName { get; set; }
    }

}
