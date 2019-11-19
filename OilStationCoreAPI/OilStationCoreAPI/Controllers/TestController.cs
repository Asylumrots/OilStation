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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilStationCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    //测试
    public class TestController : ControllerBase
    {
        public TestController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [HttpGet]
        public async Task<int> reg()
        {
            var user = await _userManager.CreateAsync(new ApplicationUser
            { UserName = "admin2", Email = "12345678@qq.com", UserSex = "1", BirthDay = Convert.ToDateTime("1999-12-05"), Address = "湖北武汉", Status = 1, CreateTime = DateTime.Now.ToLocalTime(), UpdateTime = DateTime.Now.ToLocalTime(), JobId = "1", OrgId = "1", IsHSEGroup = 0 }, "Qq123.");
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
    }
}
