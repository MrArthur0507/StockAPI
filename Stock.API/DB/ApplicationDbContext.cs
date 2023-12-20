using Microsoft.EntityFrameworkCore;
using Stocks.Models;

namespace Stocks.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResponseData>()
                .Property(r => r.TimeSeries)
                .HasConversion<string>(); 
        }

        public DbSet<ResponseData> Responses { get; set; }

    }
}
