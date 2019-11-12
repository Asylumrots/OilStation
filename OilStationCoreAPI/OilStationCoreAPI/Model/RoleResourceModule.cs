using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Model
{
    public partial class RoleResourceModule
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid ResourceModuleId { get; set; }
    }
}
