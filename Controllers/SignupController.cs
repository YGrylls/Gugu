using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Services;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {

        private IGuguUserService _userService;
        public SignupController(IGuguUserService service)
        {
            _userService = service;
        }
        [HttpPost]
        public Result signup([FromBody] UserReq req)
        {
            if (!req.validate())
            {
                return Result.failResult("格式有误", null);
            }
            bool res = _userService.AddUser(req.username, req.password);
            if (res)
            {
                return Result.successResult("注册成功", req.username);
            }else
            {
                return Result.failResult("用户存在", null);
            }
        }
    }
}