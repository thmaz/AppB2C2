using System.ComponentModel;
using AppB2C2.Models.Domain;
using Microsoft.AspNetCore.Http;


namespace AppB2C2.Models.ViewModels
{
    public class AddMusicItemRequest
    {
        public string ItemTitle { get; set; } // Title on page for itenm
        public string ItemDescription { get; set; } // Short description for item
        public string? ImageUrl { get; set; } // Url for image included in post
        public string Artist { get; set; } // Associated artist
        public string ItemContent { get; set; } // Elaborated description of item
        public DateTime? DateAdded { get; set; } // Date posted
        public float ItemValue { get; set; } // Value of item
        [DisplayName("Upload Image")]
        public IFormFile ImageFile {  get; set; } 
        public List<Guid> TagIds { get; set; }
        public MusicItemType ItemType { get; set; }
    }
}
