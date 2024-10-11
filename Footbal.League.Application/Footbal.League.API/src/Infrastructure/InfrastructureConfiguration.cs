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
                //.AddDbContext<AppDbContext>(options => options
                //    .UseNpgsql(
                //        configuration.GetConnectionString("DefaultConnection"),
                //        sqlServer => sqlServer
                //            .MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)))
                //.AddScoped<IFootballDbContext>(provider => provider.GetService<AppDbContext>()!)
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
