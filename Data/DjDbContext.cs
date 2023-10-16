using AppB2C2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppB2C2.Data
{
    public class DjDbContext : DbContext
    {
        public DjDbContext(DbContextOptions options) : base(options) // Constructor for passing options to base class
        {
        }

        public DbSet<MusicItem> MusicItems { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
    }
}
