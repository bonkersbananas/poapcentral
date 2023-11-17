namespace backend.api.Models
{
    public class Event
    {
        public required string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<Poap>? RequiredPoaps { get; set; }
    }
}
