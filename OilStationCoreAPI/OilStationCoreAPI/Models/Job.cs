using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public bool? IsDel { get; set; }
    }
}
