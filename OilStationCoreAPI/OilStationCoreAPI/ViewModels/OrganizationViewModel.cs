using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class OrganizationViewModel
    {
        public string id { get; set; }
        public string label { get; set; }
        public string code { get; set; }
        public List<OrganizationViewModel> children { get; set; }
    }
}
