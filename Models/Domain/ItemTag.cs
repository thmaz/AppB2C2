namespace AppB2C2.Models.Domain
{
    public class ItemTag
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public string DisplayName { get; set; }
        public float TagPrice {  get; set; }
        public ICollection<MusicItem> MusicItems { get; set; }

    }
}