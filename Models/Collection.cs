using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AppB2C2.Models
{
    public class Collection
    {
        public int CollectionId { get; set; } //primary key
        [Required] public string? CollectionName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CollectionDescription { get; set; }
        public int? AddedItems { get; set; }

        public ICollection<CollectionItem>? CollectionItems { get; set; }
        public User? User { get; set; }
        public CollectionItem? CollectionItem { get; set; } 
    }
}
