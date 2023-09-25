using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppB2C2.Models
{
	public class CollectionItem
	{
		[Key] public int ItemId { get; set; }
		[Required] public string? ItemName { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public string? ItemDescription { get; set; }
		public int ReleaseDate { get; set; }
		public int EstimatedPrice { get; set; }
		public int CollectionId { get; set; } //foreign key
		public Collection Collection { get; set; }
	}
}
