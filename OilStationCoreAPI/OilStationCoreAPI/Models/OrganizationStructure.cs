using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class OrganizationStructure
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Leve { get; set; }
        public Guid? ParentId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDel { get; set; }
    }
}
