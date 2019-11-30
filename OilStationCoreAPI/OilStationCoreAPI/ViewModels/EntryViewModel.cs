using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class EntryViewModel
    {
        public string Id { get; set; }
        public string StaffName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string ProbationarySalary { get; set; }
        public string CorrectSalary { get; set; }
        public DateTime EntryDate { get; set; }
        public string CreateStaffeId { get; set; }
        public DateTime CreateTime { get; set; }
        public string WorkNumber { get; set; }
        //审核信息
        public string Title { get; set; }
        //审核
        public string No { get; set; }
        public bool IsDel { get; set; } 
    }
}
