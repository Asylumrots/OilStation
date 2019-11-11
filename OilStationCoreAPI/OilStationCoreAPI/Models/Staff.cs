using System;
using System.Collections.Generic;

namespace OilStationCoreAPI.Models
{
    public partial class Staff
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public bool? Sex { get; set; }
        public DateTime? BirthDay { get; set; }
        public string NativePlace { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? JobId { get; set; }
        public Guid? OrgId { get; set; }
        public bool? IsHsegroup { get; set; }
    }
}
