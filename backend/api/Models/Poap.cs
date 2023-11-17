namespace backend.api.Models
{
    public class Poap
    {
        public required string Id { get; set; }
        public string? Url { get; set; }
        public required string Status { get; set; }

        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
