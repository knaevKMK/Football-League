namespace Domain.Common.Models
{
    using Bogus;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.Common.Extensions;
    using Domain.Common.Services;
    using FluentAssertions;  
    using Xunit;

    public class EntitySpecs : IClassFixture<FakeDateTimeProviderFakes>
    {
        private readonly FakeDateTimeProviderFakes _dateTimeProviderFakes;

        public EntitySpecs(FakeDateTimeProviderFakes fakeProvider)
        {
            _dateTimeProviderFakes = fakeProvider;
        }

        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            var id = Guid.NewGuid();
           
            var first = new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(id);

            var second =  new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(id); ;

            // Act
            var result = first == second;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
            var first = new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(Guid.NewGuid());

            var second = new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(Guid.NewGuid());

            // Act
            var result = first == second;

            // Assert
            result.Should().BeFalse();
        }
    }


}
