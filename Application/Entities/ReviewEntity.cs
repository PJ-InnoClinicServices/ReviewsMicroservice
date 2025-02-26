using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Enums;

namespace Application.Entities
{
    public class ReviewEntity
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; init; }

        [BsonElement("DoctorId")]
        [BsonRepresentation(BsonType.String)]
        public Guid DoctorId { get; init; }
        
        [BsonElement("PatientId")]
        [BsonRepresentation(BsonType.String)]
        public Guid PatientId { get; init; }

        [BsonElement("AppointmentId")]
        [BsonRepresentation(BsonType.String)]
        public Guid AppointmentId { get; init; }

        [BsonElement("Rating")]
        [BsonRepresentation(BsonType.Int32)]
        public Rating Rating { get; init; }

        [BsonElement("Comment")]
        public string Comment { get; init; }

        [BsonElement("ReviewerName")]
        public string ReviewerName { get; init; }

        [BsonElement("CreatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; init; }

        [BsonElement("UpdatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedAt { get; init; }

        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public ReviewStatus Status { get; init; }
    }
}
