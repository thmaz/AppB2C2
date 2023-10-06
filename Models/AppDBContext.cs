using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2.Models
{
    public class AppDBContext : DbContext
	{
		public DbSet<CollectionItem> CollectionItems { get; set; }
		public DbSet<Collection> Collections { get; set; }
		public DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<CollectionItem>()
                .Property(i => i.ItemName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<CollectionItem>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<CollectionItem>()
                .HasOne(ci => ci.Collection)
                .WithMany(c => c.CollectionItems)
                .HasForeignKey(ci => ci.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Collection>()
                .Property(c => c.CollectionName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Collection>()
                .HasKey(c => c.CollectionId);

            modelBuilder.Entity<Collection>()
                .HasOne(ui => ui.User)
                .WithMany(u => u.Collections)
                .HasForeignKey(ui => ui.CollectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            SeedData(modelBuilder);
        }
		private static void SeedData(ModelBuilder modelBuilder)
		{

		}
	}
}
