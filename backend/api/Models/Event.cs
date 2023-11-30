using System.ComponentModel.DataAnnotations.Schema;

namespace backend.api.Models
{
    [Table("events")]
    public class Event
    {
        [Column("id")]
        public required string Id { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("image_url")]
        public string? ImageUrl { get; set; }
        [Column("required_poaps")]
        public List<Poap>? RequiredPoaps { get; set; }
    }
}
