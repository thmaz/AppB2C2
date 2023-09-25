using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using AppB2C2.Models;

namespace AppB2C2.Data
{
    public class TestDb : DbContext
    {
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Collection>()
                .Property(c => c.CollectionName)
                .IsRequired()
                .HasMaxLength(50);
            
			modelBuilder.Entity<User>()
				.Property(u => u.UserName)
				.IsRequired()
				.HasMaxLength(50);

            modelBuilder.Entity<CollectionItem>()
                .HasKey(i => i.ItemId);
			
			modelBuilder.Entity<CollectionItem>()
				.HasOne(ci => ci.Collection)
				.WithMany(c => c.CollectionItems)
				.HasForeignKey(ci => ci.FornItemId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Collection>()
				.HasOne(ui => ui.User)
				.WithMany(u => u.Collections)
				.HasForeignKey(ui => ui.FornCollectionId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Collection>()
				.HasKey(c => c.CollectionId);

			modelBuilder.Entity<User>()
				.HasKey(u => u.UserId);

			SeedData(modelBuilder);
        }
        private static void SeedData (ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<CollectionItem>().HasData(
				new CollectionItem
				{
					ItemId = 2,
					ItemName = "Item Test",
				});

			modelBuilder.Entity<Collection>().HasData(
				new Collection
				{
					CollectionId = 1,
					CollectionName = "Collection Test"
				});

			modelBuilder.Entity<User>().HasData(
				new User
				{
					UserId = 1,
					UserName = "Test Name",
					MailAdress = "test@home.nl", 
					UserPassword = "test_pass"
				});
		}
    }
}
