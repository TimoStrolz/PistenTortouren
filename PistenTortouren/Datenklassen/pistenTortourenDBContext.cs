using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PistenTortouren
{
    public class pistenTortourenDBContext : DbContext
    {
        public pistenTortourenDBContext() : base(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=pistenTortouren;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<OpeningTime> EpeningTimes { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
    }
}