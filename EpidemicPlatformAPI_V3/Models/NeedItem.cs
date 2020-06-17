﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class NeedItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NeedItemId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
