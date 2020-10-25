using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BannerFlow.Model
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options)
            : base(options)
        {

        }

        public DbSet<Banner> Banners { get; set; }
    }
}
