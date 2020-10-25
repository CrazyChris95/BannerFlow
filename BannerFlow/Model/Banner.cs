using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannerFlow.Model
{
    public class Banner
    {
        public int id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
