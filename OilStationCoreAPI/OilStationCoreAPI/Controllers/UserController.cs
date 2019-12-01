using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OilStationCoreAPI.AuthHepler;
using OilStationCoreAPI.IdentityModel;
using OilStationCoreAPI.IServices;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.Services;
using OilStationCoreAPI.ViewModels;
using static OilStationCoreAPI.ViewModels.CodeEnum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilStationCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IAspNetUsersServices aspNetUsersServices, IAspNetRolesServices aspNetRolesServices, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._aspNetUsersServices = aspNetUsersServices;
            this._aspNetRolesServices = aspNetRolesServices;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        private readonly IAspNetUsersServices _aspNetUsersServices;
        private readonly IAspNetRolesServices _aspNetRolesServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel<string>> Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseModel<string>
                {
                    code = (int)code.CheckError,
                    message = "用户名或密码验证未通过"
                };
            }
            var model = await _userManager.FindByNameAsync(loginViewModel.username);
            if (model != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model, loginViewModel.password, false, true);
                if (result.Succeeded)
                {
                    string token;
                    var role = await _userManager.GetRolesAsync(model);
                    var rolemodel = await _roleManager.FindByNameAsync(role[0]);
                    var claim = await _roleManager.GetClaimsAsync(rolemodel);
                    TokenModelJwt tokenModel = new TokenModelJwt();
                    if (role.Count == 0)
                    {
                        tokenModel.Uid = model.Id;
                        tokenModel.Role = null;
                        tokenModel.Claims = null;
                    }
                    else
                    {
                        tokenModel.Uid = model.Id;
                        tokenModel.Role = role[0];
                        tokenModel.Claims = claim;
                    }
                    token = JwtHelper.IssueJwt(tokenModel);
                    return new ResponseModel<string>
                    {
                        code = (int)code.Success,
                        data = token,
                        message = "登录成功,欢迎" + model.UserName,
                    };
                }
            }
            return new ResponseModel<string>
            {
                code = (int)code.LoginFaile,
                message = "登录失败,用户名或密码错误"
            };
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Info(string token)
        {
            TokenModelJwt model = JwtHelper.SerilaizeJwt(token);
            var user = await _userManager.FindByIdAsync(model.Uid);
            return Ok(new
            {
                code = (int)code.Success,
                data = new { name = user.UserName, avatar = "https://localhost:44395/img/default.png" },
                message = ""//信息获取成功
            });
        }

        [HttpGet]
        [Authorize]
        public ResponseModel<string> Logout() => new ResponseModel<string>
        {
            code = (int)code.Success,
            data = "success"
        };

        [HttpGet]
        [Authorize(Policy = "Roles_Get")]
        public ResponseModel<IEnumerable<UserAndRoleViewModel>> UserRole_Get()
        {
            return _aspNetUsersServices.UserRole_Get();
        }

        [HttpGet]
        [Authorize(Policy = "Roles_Get")]
        public ResponseModel<IEnumerable<RolesViewModel>> Roles_Get()
        {
            return _aspNetRolesServices.Roles_Get();
        }

        [HttpPut]
        [Authorize(Policy = "Roles_Update")]
        public ResponseModel<bool> Roles_Update([FromBody]UserRolesViewModel model)
        {
            return _aspNetRolesServices.Roles_Update(model);
        }

        [HttpGet]
        [Authorize(Policy = "Claim_Get")]
        public ResponseModel<IEnumerable<string>> Claim_Get(string RoleId)
        {
            return _aspNetRolesServices.Claim_Get(RoleId);
        }

        [HttpPost]
        [Authorize(Policy = "Claim_Update")]
        public ResponseModel<bool> Claim_Update([FromBody]ClaimViewModel model)
        {
            return _aspNetRolesServices.Claim_Update(model);
        }

        //[HttpGet]
        //public ResponseModel<AspNetUsers> UserInfo_Get()
        //{
        //    return 
        //}

        [HttpPut]
        [Authorize(Policy = "UserInfo_Update")]
        public ResponseModel<bool> UserInfo_Update([FromBody]UserInfoViewModel model)
        {
            return _aspNetUsersServices.UserInfo_Update(model);
        }

        [HttpDelete]
        [Authorize(Policy = "UserInfo_Delete")]
        public ResponseModel<bool> UserInfo_Delete(string id)
        {
            return _aspNetUsersServices.UserInfo_Delete(id);
        }
    }
}
