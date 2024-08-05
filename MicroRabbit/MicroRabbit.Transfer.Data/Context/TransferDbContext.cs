using Microsoft.EntityFrameworkCore;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransferLog>(entity =>
            {
                entity.Property(e => e.TransferAmount)
                      .HasColumnType("decimal(18,2)"); // TransferAmount property'sinin veri türünü "decimal(18,2)" olarak ayarlar.

                // Diğer konfigürasyonlar buraya eklenebilir.
            });
        }
    }
}
