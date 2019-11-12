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
using OilStationCoreAPI.ViewModels;
using static OilStationCoreAPI.ViewModels.CodeEnum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilStationCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        public UserController(IStaffServices staffServices,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._staffServices = staffServices;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        private readonly IStaffServices _staffServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public  async Task<ResponseModel<string>> Login([FromBody]LoginViewModel loginViewModel)
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
                    //  var userRole = "admin";
                    TokenModelJwt tokenModel = new TokenModelJwt { Uid = model.Id };
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
        public async Task<IActionResult> Info(string token)
        {
            TokenModelJwt model = JwtHelper.SerilaizeJwt(token);
            var user = await _userManager.FindByIdAsync(model.Uid);
            return Ok(new 
            {
                code = (int)code.Success,
                data = new {name=user.UserName, avatar= "https://localhost:44395/img/default.png" },
                message = "信息获取成功"
            });
        }

        [HttpGet]
        public ResponseModel<string> Logout() => new ResponseModel<string>
        {
            code = (int)code.Success,
            data = "success",
            message = ""
        };

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
    }
}
