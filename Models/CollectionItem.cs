using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppB2C2.Models
{
	public class CollectionItem
	{
		[Required] public int ItemId { get; set; } // Primary key
		public string? ItemName { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public string? ItemDescription { get; set; }
		public int ReleaseDate { get; set; }
		public float EstimatedPrice { get; set; }
		public int CollectionId { get; set; } // Foreign key
        public Collection? Collection { get; set; }

    }
}
