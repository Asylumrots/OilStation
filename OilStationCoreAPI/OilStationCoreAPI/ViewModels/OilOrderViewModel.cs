using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class OilOrderViewModel
    {
        public string Id { get; set; }
        public string No { get; set; }
        public string ApplyPersonId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Remark { get; set; }

        public string OilSpec { get; set; }
        public decimal Volume { get; set; }
        public decimal Surpuls { get; set; }
        public decimal DayAvg { get; set; }
        public decimal NeedAmount { get; set; }
    }
}
