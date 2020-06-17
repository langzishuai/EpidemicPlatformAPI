using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpidemicPlatformAPI_V3.Services
{
    public class SupplyService
    {
        private readonly PlatformContext platformContext;

        public SupplyService(PlatformContext context)
        {
            this.platformContext = context;
        }

        public void AddSupply(Supply supply)
        {
            platformContext.Supplies.Add(supply);
            platformContext.SaveChanges();
        }

        public List<Supply> GetAllSupply()
        {
            return platformContext.Supplies.Include("Items").ToList<Supply>();
        }

        public Supply GetSupplyById(int id)
        {
            return platformContext.Supplies.Include("Items").FirstOrDefault(p => p.SupplyId == id);
        }

        public List<Supply> GetSupplyByName(string name)
        {
            var query = platformContext.Supplies.Include("Items").Where(p => p.User == name);

            return query.ToList<Supply>();
        }

        public List<Supply> NeedMatch(int id)
        {
            List<Supply> supplies, retList;
            Need need = platformContext.Needs.Include("Items").FirstOrDefault(p => p.NeedId == id);
            supplies = platformContext.Supplies.Include("Items").ToList();
            var query = supplies.Where((p) =>
            {
                for (int i = 0; i < p.Items.Count; i++)
                {
                    for (int j = 0; j < need.Items.Count; j++)
                        if (p.Items[i].Name == need.Items[j].Name)
                            return true;
                }
                return false;
            });
            retList = query.ToList<Supply>();

            return retList;
        }

    }
}
