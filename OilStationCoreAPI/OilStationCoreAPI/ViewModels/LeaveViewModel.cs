using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class LeaveViewModel
    {
        public string Id { get; set; }
        public string StaffName { get; set; }
        public string LeaveType { get; set; }
        public DateTime ApplyTime { get; set; }
        public string Reason { get; set; }
        public DateTime CreateTime { get; set; }
        public string No { get; set; }
        public string JobId { get; set; }
    }
}
