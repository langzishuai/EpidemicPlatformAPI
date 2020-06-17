using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Institution { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
    }
}
