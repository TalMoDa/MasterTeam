using DreamTeam.Application.Common.Interfaces;
using DreamTeam.Domain.Constants;
using DreamTeam.Infrastructure.Data;
using DreamTeam.Infrastructure.Data.Interceptors;
using DreamTeam.Infrastructure.Identity;
using DreamTeam.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DreamTeam.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureSettings(configuration);
        
        var connectionString = services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionStrings>>().Value;

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<IApplicationDbContext, DreamTeamContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString.DefaultConnection);
        });

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<DreamTeamContext>());

        //services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        /*services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DreamTeamContext>()
            .AddApiEndpoints();*/

        services.AddSingleton(TimeProvider.System);
        //services.AddTransient<IIdentityService, IdentityService>();

        /*services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));*/

        return services;
    }


    private static IServiceCollection AddInfrastructureSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<ConnectionStrings>()
            .Bind(configuration.GetSection(nameof(ConnectionStrings)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}
