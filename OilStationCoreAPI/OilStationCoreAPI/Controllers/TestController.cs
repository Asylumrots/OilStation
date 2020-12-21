using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OilStationCoreAPI.AuthHepler;
using OilStationCoreAPI.IdentityModel;
using OilStationCoreAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilStationCoreAPI.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<int> reg()
        {
            var user = await _userManager.CreateAsync(new ApplicationUser
            { UserName = "admin3", Email = "12345678@qq.com", UserSex = "1", BirthDay = Convert.ToDateTime("1999-11-06"), Address = "湖北武汉", Status = 1, CreateTime = DateTime.Now.ToLocalTime(), UpdateTime = DateTime.Now.ToLocalTime(), JobId = "1", OrgId = "1", IsHSEGroup = 0 }, "Qq123.");
            if (user.Succeeded)
            {
                return 1;
            }
            return 0;
        }

        [HttpGet]
        public async Task<string> AddRole(string roleName)
        {
            var role = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            //var model = await _roleManager.FindByNameAsync("超级用户");
            //var role = await _roleManager.DeleteAsync(model);
            if (role.Succeeded)
            {
                return "成功";
            }
            return "失败";
        }

        [HttpGet]
        public async Task<string> AddClaim(string roleNmae,string claimKey,string claimValue)
        {
            Claim c = new Claim(claimKey, claimValue);
            var role = await _roleManager.FindByNameAsync(roleNmae);
            var claim = await _roleManager.AddClaimAsync(role, c);
            if (claim.Succeeded)
            {
                return "成功";
            }
            return "失败";
        }

        [HttpGet]
        [Authorize]
        public int Authorize()
        {
            return 0;
        }

        [HttpGet]
        [Authorize(Policy = "Administrators")]
        public int AuthorizePolicy()
        {
            return 0;
        }

        [HttpGet]
        [Authorize(Policy = "Roles_Update")]
        public async Task<dynamic> AuthorizeClaim()
        {
            var role = await _roleManager.FindByNameAsync("Administrators");
            return await _roleManager.GetClaimsAsync(role);
        }

        [HttpGet]
        public dynamic TokenModelISS(string token)
        {
            TokenModelJwt model = JwtHelper.SerilaizeJwt(token);
            return model;
        }

        [HttpPost]
        public bool Login(TestViewModel model)
        {
            if (model.name=="123"&&model.pwd=="123")
            {
                return true;
            }
            return false;
        }


        [HttpGet]
        public string Get()
        {
            return "get";
        }
        [HttpPost]
        public string Post()
        {
            return "post";
        }
        [HttpPut]
        public string Put()
        {
            return "put";
        }
        [HttpDelete]
        public string Delete()
        {
            return "delete";
        }
    }
}
