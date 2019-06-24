using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gugu.Config;
using Gugu.Model;

namespace Gugu.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly GuguDbContext db;
        public PersonalService(GuguDbContext context)
        {
            db = context;
        }

        public List<Party> findCreateParty(int uid)
        {
            var res = (from p in db.Parties
                       join r in db.PartyMems on p.party_id equals r.party_id
                       where r.user_id == uid && r.is_leader == 1
                       select p).ToList();
            return res;
        }

        public List<Party> findJoinParty(int uid)
        {
            var res = (from p in db.Parties
                       join r in db.PartyMems on p.party_id equals r.party_id
                       where r.user_id == uid && r.is_leader == 0
                       select p).ToList();
            return res;
        }
    }
}
