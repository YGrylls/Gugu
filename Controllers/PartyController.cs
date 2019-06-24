using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gugu.Common;
using Gugu.Services;
using Gugu.Model;

namespace Gugu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private IPartyService _service;
        public PartyController(IPartyService service)
        {
            _service = service;
        }

        // GET: api/Party/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            if (id < 0) return Result.failResult("ID范围有误", null);
            var p = _service.getParty(id);
            if (p == null)
            {
                return Result.failResult("未找到队伍", null);
            }
            else
            {
                PartyInfo res = new PartyInfo();
                res.party = p;
                res.mems = _service.getMembers(p.party_id);
                return Result.successResult("OK", res);
            }
        }

        // POST: api/Party
        [HttpPost]
        public Result Post([FromBody] GetReq req)
        {
            if (!req.validate()) return Result.failResult("格式有误", null);
            var res=_service.findParties(req.game, req.type, req.aim,req.page);
            return Result.successResult("OK", res);
        }

    }
}
