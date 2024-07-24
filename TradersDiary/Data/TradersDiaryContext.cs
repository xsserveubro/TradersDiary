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

        public DbSet<DealBO> DealBO { get; set; } = default!;
        public DbSet<DealForex> DealForex { get; set; } = default!;
    }
}
