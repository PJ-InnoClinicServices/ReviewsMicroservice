using Application.Entities;
using Shared.DTOs;
using Shared.Enums;

namespace Application.Interfaces.IRepositories;

public interface IReviewsRepository : IRepository<ReviewEntity, CreateReviewDto, UpdateReviewDto, ReviewDto>
{
    Task<IEnumerable<ReviewDto>> GetReviewsByStatusAsync(ReviewStatus status);
    Task<IEnumerable<ReviewDto>> GetReviewsByRatingAsync(Rating rating);
}
