using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gugu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Model;
using Gugu.Utils;
using Gugu.Common;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalCreateController : ControllerBase
    {
        
        private IPersonalService _service;
        public PersonalCreateController(IPersonalService service)
        {
            _service = service;
        }
        [HttpPost]
        public Result findCreate()
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
            var resm = _service.findCreateParty(creator.uid);
            return Result.successResult("OK", resm);
        }
    }
}