using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace WebAPI.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewsController(IReviewService reviewService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ReviewDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateReviewDto createDto)
    {
        var createdReview = await reviewService.CreateAsync(createDto);
        return Ok(createdReview); 
    }
        

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReviewDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var review = await reviewService.GetByIdAsync(id);
        if (review == null)
            return NotFound();
        return Ok(review);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReviewDto>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        var reviews = await reviewService.GetAllAsync();
        return Ok(reviews);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ReviewDto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateReviewDto updateDto)
    {
        if (id != updateDto.Id)
            return BadRequest();

        var updatedReview = await reviewService.UpdateAsync(updateDto);
        if (updatedReview == null)
            return NotFound();

        return Ok(updatedReview);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var isDeleted = await reviewService.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}