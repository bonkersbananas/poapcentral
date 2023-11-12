namespace backend.api.Models
{
    public class Poap
    {
        public required int Id { get; set; }
        public required string Message { get; set; }
        public string? Url { get; set; }
        public bool IsDistributed { get; set; }
    }
}
