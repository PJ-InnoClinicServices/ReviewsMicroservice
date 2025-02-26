using Application.Entities;
using Application.Interfaces;
using Application.Interfaces.IServices;
using Shared.DTOs;

namespace Application.Services
{
    public class ReviewService(IRepository<ReviewEntity, CreateReviewDto, UpdateReviewDto, ReviewDto> repository)
        : IReviewService
    {
        public Task<ReviewDto> CreateAsync(CreateReviewDto createDto)
        {
            return repository.CreateAsync(createDto);
        }

        public Task<ReviewDto> GetByIdAsync(Guid id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<ReviewDto> UpdateAsync(UpdateReviewDto updateDto)
        {
            return repository.UpdateAsync(updateDto);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return repository.DeleteAsync(id);
        }
    }
}
