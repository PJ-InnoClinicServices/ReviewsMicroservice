using Application.Entities;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Infrastructure.Repositories;
using Shared.DTOs;

namespace WebAPI.Extensions
{
    public static class AddRepositories
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ReviewEntity, CreateReviewDto, UpdateReviewDto, ReviewDto>, ReviewRepository>();
            services.AddScoped<IReviewsRepository, ReviewRepository>();
            return services;
        }
    }
}