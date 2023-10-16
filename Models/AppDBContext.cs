using Microsoft.EntityFrameworkCore;

namespace AppB2C2.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<DjUser> DjUsers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=DjDb;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
                .HasKey(e => e.CollectionId);

            modelBuilder.Entity<DjUser>()
                .HasKey(e => e.UserId);

            modelBuilder.Entity<CollectionItem>()
                .HasKey(e => e.ItemId);

            modelBuilder.Entity<Collection>()
                .Property(e => e.CollectionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DjUser>()
                .HasMany(e => e.Collections)
                .WithOne(e => e.DjUser)
                .HasForeignKey(e => e.CollectionId)
                .IsRequired();

            modelBuilder.Entity<CollectionItem>()
                .HasOne(e => e.Collection)
                .WithMany(e => e.CollectionItems)
                .HasForeignKey(e => e.CollectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

    }
}
