using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class FirstRequest
    {
        public string Applicant { get; set; }
        public string Recipient { get; set; }
        public int SupplyId { get; set; }
        public int NeedId { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
        public List<Item> Items { get; set; }
    }
}
