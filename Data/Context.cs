using Microsoft.EntityFrameworkCore;

using KTGK_1.Models;

namespace KTGK_1.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<hang_hoa> Goods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hang_hoa>()
                .Property(h => h.ma_hanghoa)
                .IsFixedLength()
                .HasMaxLength(9);

            modelBuilder.Entity<hang_hoa>()
                .Property(h => h.ten_hanghoa)
                .IsRequired();
        }
    }
}
