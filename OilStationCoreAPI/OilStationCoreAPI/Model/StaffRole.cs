using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Model
{
    public partial class StaffRole
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public Guid RoleId { get; set; }
    }
}
