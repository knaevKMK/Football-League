namespace Infrastructure.BoundedContexts.FootballTeam.Configuration
{

    using Domain.BoundedContexts.FootbalTeam.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FootballRankingDbConfiguration : IEntityTypeConfiguration<FootballRankingEntity>
    {
        public void Configure(EntityTypeBuilder<FootballRankingEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.CreatedFrom)
                .IsRequired();

            builder
                .Property(c => c.CreatedOn)
                .IsRequired();

            builder
              .Property(c => c.TeamId)
              .IsRequired();

            builder
            .HasOne(c => c.Team)
            .WithOne(c => c.Rank)
            .HasForeignKey<FootballRankingEntity>(r => r.TeamId)
            .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
