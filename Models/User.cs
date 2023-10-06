using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppB2C2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? MailAdress { get; set; }
        public string? UserPassword { get; set; }
        public int CreatedCollections { get; set; }
		public ICollection<Collection>? Collections { get; set; }

	}
}
