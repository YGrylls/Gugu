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
    public class QuitController : ControllerBase
    {
        private IPartyService _service;
        public QuitController(IPartyService service)
        {
            _service = service;
        }
        [HttpPost("{id}")]
        public Result quit(int id)
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
            var resm = _service.quitParty(creator.uid, id);
            if (resm) return Result.successResult("OK", null);
            else return Result.failResult("不在队伍中或无法退出", null);
        }
    }
    
}