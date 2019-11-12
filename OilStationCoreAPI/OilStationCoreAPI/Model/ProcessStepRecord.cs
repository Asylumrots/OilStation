using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Model
{
    public partial class ProcessStepRecord
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string RecordRemarks { get; set; }
        public int StepOrder { get; set; }
        public Guid WaitForExecutionStaffId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool WhetherToExecute { get; set; }
        public string No { get; set; }
        public Guid RefOrderId { get; set; }
        public bool Result { get; set; }
        public string ExecuteMethod { get; set; }
        public string Discrible { get; set; }
    }
}
