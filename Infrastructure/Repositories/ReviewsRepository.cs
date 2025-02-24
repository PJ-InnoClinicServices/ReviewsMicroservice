using Application.Entities;
using Application.Interfaces;
using MongoDB.Driver;
using Shared.DTOs;
using Shared.Enums;

public class ReviewRepository : IReviewsRepository
{
    private readonly IMongoCollection<ReviewEntity> _reviewsCollection;

    public ReviewRepository(MongoDbService mongoDbService)
    {
        _reviewsCollection = mongoDbService.Database.GetCollection<ReviewEntity>("reviews");
    }
    public async Task<ReviewDto> CreateAsync(CreateReviewDto createDto)
    {
        var reviewEntity = new ReviewEntity
        {
            Comment = createDto.Comment,
            Rating = createDto.Rating,
            Status = ReviewStatus.Pending,  
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _reviewsCollection.InsertOneAsync(reviewEntity);

        return new ReviewDto
        {
            Id = reviewEntity.Id,
            Comment = reviewEntity.Comment,
            Rating = reviewEntity.Rating,
            Status = reviewEntity.Status,
            CreatedAt = reviewEntity.CreatedAt,
            UpdatedAt = reviewEntity.UpdatedAt
        };
    }

    public async Task<ReviewDto> GetByIdAsync(Guid id)
    {
        var reviewEntity = await _reviewsCollection
            .Find(r => r.Id == id)
            .FirstOrDefaultAsync();

        if (reviewEntity == null)
            return null;

        return new ReviewDto
        {
            Id = reviewEntity.Id,
            Comment = reviewEntity.Comment,
            Rating = reviewEntity.Rating,
            Status = reviewEntity.Status,
            CreatedAt = reviewEntity.CreatedAt,
            UpdatedAt = reviewEntity.UpdatedAt
        };
    }

    public async Task<IEnumerable<ReviewDto>> GetAllAsync()
    {
        var reviewEntities = await _reviewsCollection
            .Find(_ => true)
            .ToListAsync();

        return reviewEntities.Select(r => new ReviewDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            Status = r.Status,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        });
    }

    public async Task<ReviewDto> UpdateAsync(UpdateReviewDto updateDto)
    {
        var updateDefinition = Builders<ReviewEntity>.Update
            .Set(r => r.Comment, updateDto.Comment)
            .Set(r => r.Rating, updateDto.Rating)
            .Set(r => r.Status, updateDto.Status)
            .Set(r => r.UpdatedAt, DateTime.UtcNow);

        var result = await _reviewsCollection
            .FindOneAndUpdateAsync(r => r.Id == updateDto.Id, updateDefinition);

        if (result == null)
            return null;

        return new ReviewDto
        {
            Id = result.Id,
            Comment = result.Comment,
            Rating = result.Rating,
            Status = result.Status,
            CreatedAt = result.CreatedAt,
            UpdatedAt = result.UpdatedAt
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _reviewsCollection
            .DeleteOneAsync(r => r.Id == id);

        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsByStatusAsync(ReviewStatus status)
    {
        var reviewEntities = await _reviewsCollection
            .Find(r => r.Status == status)
            .ToListAsync();

        return reviewEntities.Select(r => new ReviewDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            Status = r.Status,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        });
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsByRatingAsync(Rating rating)
    {
        var reviewEntities = await _reviewsCollection
            .Find(r => r.Rating == rating)
            .ToListAsync();

        return reviewEntities.Select(r => new ReviewDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            Status = r.Status,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        });
    }
}
