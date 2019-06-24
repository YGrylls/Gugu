using Gugu.Common;
using Gugu.Model;
using System.Collections.Generic;

namespace Gugu.Services
{
    public interface IPartyService
    {
        int createParty(int uid, PublishReq req);
        bool joinParty(int uid, int partyId);
        bool quitParty(int uid, int partyId);
        bool setPartyStatus(int partyId, int status);
        List<Party> findParties(int game,string type,string aim,int page);
        Party getParty(int pid);
        List<string> getMembers(int pid);
        int checkMem(int uid, int pid);
        bool removeMem(string username, int pid);
        List<string> getMembersExceptLeader(int pid);
    }
}