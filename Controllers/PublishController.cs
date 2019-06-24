using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Services;
using Gugu.Model;
using Gugu.Utils;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private IPartyService _service;
        public PublishController(IPartyService service)
        {
            _service = service;
        }
        [HttpPost]
        public Result publish([FromBody] PublishReq req)
        {
            var user = HttpContext.Session.Get("User");
            if (!req.validate())
            {
                return Result.failResult("格式有误", null);
            }
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
            int id = _service.createParty(creator.uid, req);
            if (id == -1)
            {
                return Result.failResult("Error", null);
            }
            else
            {
                return Result.successResult("队伍发布成功", id);
            }
        }
    }
}