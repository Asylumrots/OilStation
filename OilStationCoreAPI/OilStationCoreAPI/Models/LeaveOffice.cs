using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class LeaveOffice
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public string StaffName { get; set; }
        public Guid JobId { get; set; }
        public string LeaveType { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string Reason { get; set; }
        public string ExplanationHandover { get; set; }
        public Guid? HandoverSatffId { get; set; }
        public Guid? ApplyPersonId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsDel { get; set; }
    }
}
