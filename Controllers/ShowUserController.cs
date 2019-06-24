using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Utils;
using Gugu.Model;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowUserController : ControllerBase
    {
        [HttpGet]
        public Result showUser()
        {
            var user = HttpContext.Session.Get("User");
            if (user == null || user.Length == 0)
            {
                return Result.failResult("登录过期", null);
            }
            else
            {
                try
                {
                    User res = (User)ByteConvert.BytesToObject(user);
                    return Result.successResult("OK", res.username);
                }catch(Exception e)
                {
                    return Result.failResult("Error", null);
                }
            }
        }
    }
}