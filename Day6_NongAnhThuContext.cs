using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day6_NongAnhThu.Models;

namespace Day6_NongAnhThu.Data
{
    public class Day6_NongAnhThuContext : DbContext
    {
        public Day6_NongAnhThuContext (DbContextOptions<Day6_NongAnhThuContext> options)
            : base(options)
        {
        }

        public DbSet<Day6_NongAnhThu.Models.producr> producr { get; set; } = default!;
    }
}
