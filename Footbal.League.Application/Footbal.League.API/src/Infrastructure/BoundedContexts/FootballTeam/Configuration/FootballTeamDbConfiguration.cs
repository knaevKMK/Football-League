namespace Infrastructure.BoundedContexts.FootballTeam.Configuration
{ 
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.BoundedContexts.FootbalTeam.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FootballTeamDbConfiguration : IEntityTypeConfiguration<FootballTeamEntity>
    {
        public void Configure(EntityTypeBuilder<FootballTeamEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.CreatedFrom)
                .IsRequired();

            builder
                .Property(c => c.CreatedOn)
                .IsRequired();

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
              .Property(c => c.Description)
              .HasMaxLength(500);

            builder
             .Property(c => c.RankId)
             .IsRequired();


            builder
            .HasOne(c => c.Rank)
            .WithOne(c => c.Team)
            .HasForeignKey<FootballRankingEntity>(r => r.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasMany(c => c.HomeMatches)
            .WithOne(c => c.HomeTeam)
            .HasForeignKey(c => c.HomeTeamId)
            .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(c => c.GuestMatches)
                .WithOne(c => c.GuestTeam)
                .HasForeignKey(c => c.GuestTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
