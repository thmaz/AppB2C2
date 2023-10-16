using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AppB2C2.Models
{
    public class Collection
    {
        public int CollectionId { get; set; } //primary key
        public string? CollectionName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CollectionDescription { get; set; }
        public ICollection<CollectionItem>? CollectionItems { get; set; }
        public DjUser? DjUser { get; set; }
    }
}
