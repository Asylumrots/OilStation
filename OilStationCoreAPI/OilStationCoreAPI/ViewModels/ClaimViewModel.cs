using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class ClaimViewModel
    {
        public string  RoleId { get; set; }
        public List<string> ClaimList { get; set; }
    }
}
