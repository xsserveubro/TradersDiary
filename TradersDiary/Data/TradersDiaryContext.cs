using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradersDiary.Models;

namespace TradersDiary.Data
{
    public class TradersDiaryContext : DbContext
    {
        public TradersDiaryContext (DbContextOptions<TradersDiaryContext> options)
            : base(options)
        {
        }

        public DbSet<TradersDiary.Models.Deal> Deal { get; set; } = default!;
    }
}
