using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AppB2C2.Models
{
    public class Collection
    {
        [Key] public int CollectionId { get; set; } //primary key
        [Required] public string? CollectionName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CollectionDescription { get; set; }
        public int? AddedItems { get; set; }

        public ICollection<CollectionItem>? CollectionItems { get; set; }
        public int FornCollectionId { get; set; } //foreign key
        public User? User { get; set; }
    }
}
