using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gugu.Config;
using Microsoft.EntityFrameworkCore;
using Gugu.Model;
namespace Gugu.Services
{


    public class GuguUserService : IGuguUserService
    {
        private readonly GuguDbContext db;
        public GuguUserService(GuguDbContext context)
        {
            db = context;
        }
        public bool AddUser(string username, string password)
        {
            var findExisting = (from u in db.Users
                                where u.username == username
                                select u);
            if (findExisting.Count() >= 1)
            {
                return false;
            }
            User newUser = new User();
//            newUser.uid = -1;
            newUser.username = username;
            newUser.password = password;
            db.Users.Add(newUser);
            db.SaveChanges();
            return true;
        }

        public User CheckUser(string username, string password)
        {
            var findUser = (from u in db.Users
                            where u.username == username
                            select u);
            if (findUser.Count() != 1)
            {
                return null;
            }
            var user = findUser.Single();
            if (user.password == password)
            {
                return user ;
            }
            else return null;
        }
    }
}
