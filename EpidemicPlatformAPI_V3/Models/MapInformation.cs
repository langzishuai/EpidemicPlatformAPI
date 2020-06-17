using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class MapInformation
    {
        public List<string> days { get; set; }
        public List<string> news { get; set; }
        public List<List<int>> lists { get; set; }
    }
}
