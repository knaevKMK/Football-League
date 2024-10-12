namespace Infrastructure
{
    using Application.Common.Contracts;
    using Infrastructure.Common;
    using Infrastructure.Common.Events;
    using Infrastructure.Common.Persistence;
    using Domain.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Infrastructure.BoundedContexts.FootballTeam;
    using Infrastructure.BoundedContexts.FootballMatch;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<FootballAppDbContext>(options => options
                    .UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(FootballAppDbContext).Assembly.FullName)))
                .AddScoped<IFootballTeamDbContext>(provider => provider.GetService<FootballAppDbContext>()!)
                .AddScoped<IFootballMatchDbContext>(provider => provider.GetService<FootballAppDbContext>()!)
                .AddTransient<IInitializer, DatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
