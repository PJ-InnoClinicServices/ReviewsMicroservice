using Shared.Enums;

namespace Shared.DTOs
{
    public record ReviewDto
    {
        public Guid Id { get; set; }
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ReviewStatus Status { get; set; }
    }
}