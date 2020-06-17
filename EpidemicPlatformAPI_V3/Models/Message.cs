using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string Applicant { get; set; }
        public string Recipient { get; set; }
        public int SupplyId { get; set; }
        public int NeedId { get; set; }
        public string MessageType { get; set; }
        public string Time { get; set; }
        public string MeaasgeState { get; set; }
        public string Reason { get; set; }
        public List<Item> Items { get; set; }
    }
}
