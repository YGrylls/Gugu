using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Services;
using Gugu.Utils;
using Gugu.Common;
using Gugu.Model;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckMemController : ControllerBase
    {
        private readonly IPartyService _service;
        public CheckMemController(IPartyService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public Result checkMem(int id)
        {
            var user = HttpContext.Session.Get("User");
            User creator = null;
            if (user == null || user.Length == 0)
            {
                return Result.failResult("登录过期", null);
            }
            else
            {
                try
                {
                    User res = (User)ByteConvert.BytesToObject(user);
                    creator = res;
                }
                catch (Exception e)
                {
                    return Result.failResult("Error", null);
                }
            }
            int resm=_service.checkMem(creator.uid,id);
            return Result.successResult("OK", resm);
        }
    }
}