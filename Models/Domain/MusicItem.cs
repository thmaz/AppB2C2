using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using AppB2C2.Models.Domain;

namespace AppB2C2.Models.Domain
{
    public enum MusicItemType
    {
        CD,
        LP,
        Cassette
    }
    /// <summary>
    /// Represents music item class
    /// </summary>
    public class MusicItem
    {
        /// <summary>
        /// Unique identifier for music item
        /// </summary>
        public Guid Id { get; set; } // Key
        
        /// <summary>
        /// Title for music item
        /// </summary>
        public string ItemTitle { get; set; }
        
        /// <summary>
        /// Short description for music item, for example defining item condition
        /// </summary>
        public string ItemDescription { get; set; }
       
        /// <summary>
        /// Defines url for the image included in the post
        /// </summary>
        public string? ImageUrl {  get; set; }
        
        /// <summary>
        /// Defines artist for music item
        /// </summary>
        public string Artist { get; set; }
        
        /// <summary>
        /// Elaborate description of an item
        /// </summary>
        public string ItemContent { get; set; }
        
        /// <summary>
        /// When was the item acquired
        /// </summary>
        public DateTime? DateAdded { get; set; } 
        
        /// <summary>
        /// Responsible for value of an item
        /// </summary>
        public float ItemValue { get; set; } 
        
        /// <summary>
        /// Sets many to many relationship with itemtag
        /// </summary>
        public ICollection<ItemTag> ItemTags { get; set;} 

        public MusicItemType ItemType { get; set; }
    }
}
