namespace  Domain.Common.Models
{
    using Bogus;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.Common.Extensions;
    using Domain.Common.Services;
    using FluentAssertions;
    using Xunit;
     

    public class BaseEntitySpecs : IClassFixture<FakeDateTimeProviderFakes>
    {
        private readonly FakeDateTimeProviderFakes _dateTimeProviderFakes;

        public BaseEntitySpecs(FakeDateTimeProviderFakes fakeProvider)
        {
            _dateTimeProviderFakes = fakeProvider;
        }

        [Fact]
        public void OnCreation_ValidatesConstructor_ShouldBeValid()
        {
            var faker = new Faker();
            DateTime randomDate = faker.Date.Soon();

            _dateTimeProviderFakes.UtcNow = randomDate;

            var model = new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(Guid.NewGuid()); 

            model.CreatedOn.Should().Be(randomDate);
        }

        [Fact]
        public void OnCreation_ValidatesConstructor_ShouldNotBe()
        {
            var faker = new Faker();
            DateTime randomDate = faker.Date.Soon();

            _dateTimeProviderFakes.UtcNow = randomDate;

            // Act
            var model = new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.NewGuid(),
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(Guid.NewGuid());

            randomDate = randomDate.AddMinutes(1);

            // Assert
            model.CreatedOn.Should().NotBe(randomDate);
        }

        [Fact]
        public void OnEmptyCreatedFrom_ValidatesConstructor_ShouldThrowBaseDomainException()
        {
            // Act
            Action act = () => new Faker<FootballTeamEntity>()
                .CustomInstantiator(f => new FootballTeamEntity(
                    Guid.Empty,
                    "Team Name",
                    f.Lorem.Letter(100),
                    _dateTimeProviderFakes))
                .Generate()
                .SetId(Guid.NewGuid());

            // Assert
            act.Should().Throw<BaseDomainException>();
        }
    }
}
