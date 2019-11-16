using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class UserRolesViewModel
    {
        [Required(ErrorMessage = "用户名ID不能为空")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "角色ID不能为空")]
        public string RoleId { get; set; }
    }
}
