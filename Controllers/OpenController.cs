using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Model;
using Gugu.Utils;
using Gugu.Services;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenController : ControllerBase
    {
        private readonly IPartyService _service;
        public OpenController(IPartyService service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        public Result openParty(int id)
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
            var auth = _service.checkMem(creator.uid, id);
            if (auth != 2) return Result.failResult("没有权限", null);
            var resm=_service.setPartyStatus(id, 0);
            if (resm) return Result.successResult("OK", null);
            else return Result.failResult("队伍处于开启状态", null);
        }

    }
}