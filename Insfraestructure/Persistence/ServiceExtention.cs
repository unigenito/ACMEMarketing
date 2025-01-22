using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class ServiceExtention
{
    public static void AddInsfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(configuration["ConnectionStrings:DefaultConnection"]));
    }
}