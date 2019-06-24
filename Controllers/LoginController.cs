using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Services;
using Gugu.Utils;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IGuguUserService _userService;
        public LoginController(IGuguUserService service)
        {
            _userService = service;
        }
        // POST: api/Login
        [HttpPost]
        public Result Post([FromBody] UserReq req)
        {
            if (!req.validate())
            {
                return Result.failResult("格式有误", null);
            }
            var res=_userService.CheckUser(req.username, req.password);
            if(res!=null && res.username == req.username)
            {
                var ret= Result.successResult("登陆成功", res);
                HttpContext.Session.Set("User", ByteConvert.ObjectToBytes(res));
                Console.WriteLine(ret.message);
                return ret;
            }
            else
            {
                var ret= Result.failResult("未有匹配的账号密码", null);
                Console.WriteLine(ret.message);
                return ret;
            }
        }
    }
}
