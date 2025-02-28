using Shared.Enums;

namespace Shared.DTOs;

public record UpdateReviewDto
{
    public Guid Id { get; set; }              
    public Rating Rating { get; set; }        
    public string Comment { get; set; }          
    public ReviewStatus Status { get; set; }   
}
