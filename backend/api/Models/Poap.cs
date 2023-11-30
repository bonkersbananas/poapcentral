using System.ComponentModel.DataAnnotations.Schema;

namespace backend.api.Models
{
    [Table("poaps")]
    public class Poap
    {
        [Column("id")]
        public required string Id { get; set; }

        [Column("url")]
        public string? Url { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
