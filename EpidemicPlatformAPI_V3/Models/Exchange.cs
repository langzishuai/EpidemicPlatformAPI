using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class Exchange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExchangeId { get; set; }
        public int SupplyId { get; set; }
        public int NeedId { get; set; }
        public string Time { get; set; }
        public string Supplicant { get; set; }
        public string Requestor { get; set; }
        public string ItemName { get; set; }
        public string ItemCount { get; set; }
        public string Type { get; set; }
    }
}
