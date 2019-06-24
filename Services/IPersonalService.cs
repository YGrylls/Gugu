using Gugu.Common;
using Gugu.Model;
using System.Collections.Generic;


namespace Gugu.Services
{
    public interface IPersonalService
    {
        List<Party> findCreateParty(int uid);
        List<Party> findJoinParty(int uid);
    }
}