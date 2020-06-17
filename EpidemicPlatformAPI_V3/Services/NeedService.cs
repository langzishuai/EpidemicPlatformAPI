using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpidemicPlatformAPI_V3.Services
{
    public class NeedService
    {
        private readonly PlatformContext platformContext;

        public NeedService(PlatformContext context)
        {
            this.platformContext = context;
        }

        public void AddNeed(Need need)
        {
            platformContext.Needs.Add(need);
            platformContext.SaveChanges();
        }

        public List<Need> GetAllNeed()
        {
            return platformContext.Needs.Include("Items").ToList<Need>();
        }

        public Need GetNeedById(int id)
        {
            return platformContext.Needs.Include("Items").FirstOrDefault(p => p.NeedId == id);
        }

        public List<Need> GetNeedByName(string name)
        {
            var query = platformContext.Needs.Include("Items").Where(p => p.User == name);

            return query.ToList<Need>();
        }
    }
}
