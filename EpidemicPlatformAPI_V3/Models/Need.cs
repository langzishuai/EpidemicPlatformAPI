using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class Need
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NeedId { get; set; }
        public string User { get; set; }
        public string PhoneNumber { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public List<NeedItem> Items { get; set; }
    }
}
