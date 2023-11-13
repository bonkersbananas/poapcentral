namespace backend.api.Models
{
    public class Poap
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public required string Status { get; set; }
    }
}
