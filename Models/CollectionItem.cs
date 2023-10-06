	using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppB2C2.Models
{
	public class CollectionItem
	{
		public int ItemId { get; set; }
		[Required] public string? ItemName { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public string? ItemDescription { get; set; }
		public int ReleaseDate { get; set; }
		public float EstimatedPrice { get; set; }
		public Collection? Collection { get; set; }
	}
}
