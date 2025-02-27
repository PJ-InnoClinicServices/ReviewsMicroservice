using Application.Entities;
using Shared.DTOs;

namespace Application.Interfaces.IServices
{
    public interface IReviewService : IService<ReviewEntity, CreateReviewDto, UpdateReviewDto, ReviewDto>
    {
    }
}