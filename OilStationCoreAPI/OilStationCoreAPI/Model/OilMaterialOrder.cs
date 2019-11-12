using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Model
{
    public partial class OilMaterialOrder
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public Guid ApplyPersonId { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string Remark { get; set; }
        public bool IsDel { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
