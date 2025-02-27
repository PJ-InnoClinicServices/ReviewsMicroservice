using Application.Interfaces.IServices;
using Application.Services;

namespace WebAPI.Extensions;

public static class AddServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IReviewService, ReviewService>();
        return services;
    }
}