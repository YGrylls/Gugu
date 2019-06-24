using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gugu.Common;
using Gugu.Config;
using Gugu.Model;

namespace Gugu.Services
{
    public class PartyService : IPartyService
    {

        private readonly GuguDbContext db;
        public PartyService(GuguDbContext context)
        {
            db = context;
        }

        public int checkMem(int uid, int pid)
        {
            if (pid == 0) return 0;
            try
            {
                var res = (from m in db.PartyMems
                           where m.party_id == pid && m.user_id == uid
                           select m).Single();
                if (res.is_leader == 1) { return 2; }
                else return 1;
            }
            catch(Exception e)
            {
                return 0;
            }
            
            
           
        }

        public int createParty(int uid, PublishReq req)
        {
            Party newParty = new Party();
            newParty.pubtime = DateTime.Now;
            newParty.party_name = req.title;
            newParty.party_desc = req.desc;
            newParty.party_type = req.type;
            newParty.party_connection = req.connection;
            newParty.party_aim = req.aim;
            if (req.noob)
            {
                newParty.party_noob = 1;
            }
            else newParty.party_noob = 0;
            if (req.longterm)
            {
                newParty.party_longterm = 1;
            }
            else newParty.party_longterm = 0;
            newParty.party_game = req.game;
            newParty.party_status = 0;
            newParty.party_num = req.num;
            newParty.current_num = 0;
            try
            {
                var maxID = (from x in db.Parties
                             select x.party_id).Max() + 1;
                newParty.party_id = maxID;
                var newMem = new PartyMem();
                newMem.party_id = maxID;
                newMem.user_id = uid;
                newMem.is_leader = 1;
                db.Parties.Add(newParty);
                db.PartyMems.Add(newMem);
                db.SaveChanges();
                return maxID;
            }catch(Exception e)
            {
               
                return -1;
            }
            
            
        }

        public List<Party> findParties(int game, string type, string aim,int page)
        {
            List<Party> res = null;
            if (type == "" && aim == "")
            {
                res = (from p in db.Parties
                       where p.party_game == game && p.party_status==0 && p.current_num<p.party_num
                       select p).OrderByDescending(p => p.pubtime).Skip(20 * (page - 1)).Take(20).ToList();
            }
            else if (type != "" && aim=="")
            {
                res = (from p in db.Parties
                           where p.party_game == game && p.party_type == type && p.party_status == 0 && p.current_num < p.party_num
                       select p).OrderByDescending(p => p.pubtime).Skip(20 * (page - 1)).Take(20).ToList();

            }
            else if (type==""&& aim != "")
            {
                res = (from p in db.Parties
                           where p.party_game == game && p.party_aim == aim && p.party_status == 0 && p.current_num < p.party_num
                       select p).OrderByDescending(p => p.pubtime).Skip(20 * (page - 1)).Take(20).ToList();
            }
            else
            {
                res = (from p in db.Parties
                           where p.party_game == game && p.party_type == type && p.party_aim == aim && p.party_status == 0 && p.current_num < p.party_num
                       select p).OrderByDescending(p => p.pubtime).Skip(20 * (page - 1)).Take(20).ToList();
            }
            return res;
            
        }

        public List<string> getMembers(int pid)
        {
            var mems = (from m in db.PartyMems
                        join u in db.Users on m.user_id equals u.uid
                        where m.party_id == pid
                        select u.username).ToList<string>();
            return mems;
        }

        public List<string> getMembersExceptLeader(int pid)
        {
            var mems = (from m in db.PartyMems
                        join u in db.Users on m.user_id equals u.uid
                        where m.party_id == pid && m.is_leader==0
                        select u.username).ToList<string>();
            return mems;
        }

        public Party getParty(int pid)
        {
            var p=db.Parties.Find(pid);
            return p;
        }

        public bool joinParty(int uid, int partyId)
        {
            var p = db.Parties.Find(partyId);
            if (p == null) return false;
            if (p.party_status != 0) return false;
            if (p.current_num >= p.party_num) return false;
            var res = (from m in db.PartyMems
                       where m.party_id == partyId && m.user_id == uid
                       select m).Count();
            if (res != 0) return false;
            PartyMem newMem = new PartyMem();
            newMem.is_leader = 0;
            newMem.user_id = uid;
            newMem.party_id = partyId;
            db.PartyMems.Add(newMem);
            db.SaveChanges();
            return true;
        }

        public bool quitParty(int uid, int partyId)
        {
            try
            {
                var res = (from m in db.PartyMems
                           where m.party_id == partyId && m.user_id == uid && m.is_leader == 0
                           select m).Single();
                db.PartyMems.Remove(res);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
            
        }

        public bool removeMem(string username, int pid)
        {
            try
            {
                var target = (from u in db.Users
                              where u.username == username
                              select u.uid).Single();
                var rel = (from r in db.PartyMems
                           where r.user_id == target
                           select r).Single();
                db.PartyMems.Remove(rel);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool setPartyStatus(int partyId, int status)
        {
            try
            {
                var res = db.Parties.Find(partyId);
                if (res == null) return false;
                if (res.party_status == status) return false;
                res.party_status = status;
                db.Parties.Attach(res);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
