using Shared.Enums;

namespace Shared.DTOs;

public record CreateReviewDto
{
    public Guid DoctorId { get; set; }         
    public Guid PatientId { get; set; }        
    public Guid AppointmentId { get; set; }    
    public Rating Rating { get; set; }
    public string Comment { get; set; }
    public string ReviewerName { get; set; }
    public ReviewStatus Status { get; set; }
}