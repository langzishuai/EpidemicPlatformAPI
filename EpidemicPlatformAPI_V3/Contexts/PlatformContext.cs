using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EpidemicPlatformAPI_V3.Models;

namespace EpidemicPlatformAPI_V3.Contexts
{
    public class PlatformContext:DbContext
    {
        public PlatformContext(DbContextOptions<PlatformContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<NeedItem> NeedItems { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<EveryDataAndNews> EveryDataAndNewes { get; set; }
    }
}
