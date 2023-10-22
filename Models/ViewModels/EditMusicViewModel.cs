using System.ComponentModel;

namespace AppB2C2.Models.ViewModels
{
    public class EditMusicViewModel
    {
        public Guid Id { get; set; }
        public string ItemTitle { get; set; } // Title on page for itenm
        public string ItemDescription { get; set; } // Short description for item
        public string? ImageUrl { get; set; } // Url for image included in post
        public string Artist { get; set; } // Associated artist
        public string ItemContent { get; set; } // Elaborated description of item
        public string UrlHandle { get; set; } // Url handle for making shring links easier
        public bool Visible { get; set; } // Set to hide or show item to other users
        public DateTime? DateAdded { get; set; } // Date posted
        public float? ItemValue { get; set; } // Value of item
        //[DisplayName("Tags")]
        //public List<string> TagIds { get; set; }
    }
}
