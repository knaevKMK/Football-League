using Infrastructure.BoundedContexts.FootballMatch;
using Infrastructure.BoundedContexts.FootballTeam;
using Infrastructure.Common.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using System.Reflection;
using Xunit;

namespace Infrastructure.Common.Persistence
{
    public class FootballAppDbContextSpecs
    {
        [Fact]
        public async Task RaisedEventsShouldBeHandled()
        {
            // Arrange
            var services = new ServiceCollection()
                .AddDbContext<FootballAppDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IFootballMatchDbContext>(provider => provider
                    .GetService<FootballAppDbContext>()!)
                .AddScoped<IFootballTeamDbContext>(provider => provider
                    .GetService<FootballAppDbContext>()!) 
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();
        }
    }
}
