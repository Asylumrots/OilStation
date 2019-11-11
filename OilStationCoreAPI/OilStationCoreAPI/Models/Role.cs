using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
