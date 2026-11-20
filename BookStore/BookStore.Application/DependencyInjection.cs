using BookStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // ثبت سرویس‌های لایه Application
        services.AddScoped<BookService>();

        return services;
    }
}