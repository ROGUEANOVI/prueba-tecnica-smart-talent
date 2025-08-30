using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                entity.Property(p => p.Description)
                    .IsRequired(false)
                    .HasMaxLength(255);

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");

                entity.Property(p => p.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");

                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Product_Price",
                    "[Price] > 0"
                ));
            });
        }
    }
}
