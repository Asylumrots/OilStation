using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class SystemResourceModule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public Guid? ParentId { get; set; }
        public int? OrderNo { get; set; }
    }
}
