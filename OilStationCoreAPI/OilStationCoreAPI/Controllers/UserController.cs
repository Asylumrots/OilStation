using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OilStationCoreAPI.AuthHepler;
using OilStationCoreAPI.Models;
using OilStationCoreAPI.ViewModels;
using static OilStationCoreAPI.ViewModels.CodeEnum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilStationCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        OSMSContext db = new OSMSContext();
        // POST api/<controller>
        [HttpPost]
        public ResponseModel<string> Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseModel<string>
                {
                    code = (int)code.CheckError,
                    message = "用户名或密码验证未通过"
                };
            }
            var model = db.Staff.Where(u => u.No == loginViewModel.username && u.Password == loginViewModel.password).FirstOrDefault();
            if (model != null)
            {
                string token;
              //  var userRole = "admin";
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = "1" };
                token = JwtHelper.IssueJwt(tokenModel);
                return new ResponseModel<string>
                {
                    code = (int)code.Success,
                    data = token,
                    message = "登录成功,欢迎" + model.Name,
                };
            }
            else
            {
                return new ResponseModel<string>
                {
                    code = (int)code.LoginFaile,
                    message = "登录失败,用户名或密码错误"
                };
            }
        }

        [HttpPost]
        public IActionResult Info(string token)
        {
            TokenModelJwt model = JwtHelper.SerilaizeJwt(token);
            return Ok(new 
            {
                code = (int)code.Success,
                data = new {name=model.Uid, avatar= "https://localhost:44395/img/default.png" },
                message = "信息获取成功"
            });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return Ok(new ResponseModel<string>
            {
                code = (int)code.Success,
                data = "success"
            });
        }
    }
}
