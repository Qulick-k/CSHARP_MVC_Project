using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public partial class KcgContext : DbContext
    {
        public KcgContext(DbContextOptions<KcgContext> options) : base(options)
        {
        }

        public DbSet<TOPMenu> TOPMenu { get; set; }

        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Database=Web;Trusted_Connection=True;TrustServerCertificate=True;User ID=Web;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TOPMenu>(entity =>
            {
                entity.Property(e => e.TOPMenuId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Icon).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Url).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Orders).IsRequired();
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime");
                entity.Property(e => e.EndDateTime)
                    .HasColumnType("datetime");
                entity.Property(e => e.UpdateDateTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.InsertDateTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Enable).HasDefaultValue(true);
            });
        }


    }
}
