using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpGet]
        public Gugu.Common.Result logout()
        {
            HttpContext.Session.Clear();
            return Gugu.Common.Result.successResult("OK", null);
        }
    }
}