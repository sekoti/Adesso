using AdessoDraw.Application.Interfaces;
using AdessoDraw.Application.Services;
using AdessoDraw.Domain.UOW;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoDraw.Infrastructure.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        #region Services
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDrawService, DrawService>();
        #endregion
        return services;
    }
}