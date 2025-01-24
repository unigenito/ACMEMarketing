using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared;

public static class ServiceExtention
{
    public static void AddSharedLayer(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();
    }
}