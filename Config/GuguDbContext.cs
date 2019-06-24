using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gugu.Model;

namespace Gugu.Config
{
    public class GuguDbContext : DbContext
    {
        public GuguDbContext(DbContextOptions<GuguDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyMem> PartyMems { get; set; }
    }
}
