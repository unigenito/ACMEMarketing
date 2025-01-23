using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;

namespace Persistence;

public static class ServiceExtention
{
    public static void AddInsfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
            );
        services.AddScoped<IUnitOfwork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReposirtory<>));
        
    }
}