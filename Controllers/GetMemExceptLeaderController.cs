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
    public class GetMemExceptLeaderController : ControllerBase
    {
        private readonly IPartyService _service;
        public GetMemExceptLeaderController(IPartyService service)
        {
            _service = service;
        }
        [HttpPost("{id}")]
        public Result getMemExceptLeader(int id)
        {
            var res = _service.getMembersExceptLeader(id);
            return Result.successResult("OK", res);
        }
    }
}