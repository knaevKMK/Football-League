namespace Infrastructure.BoundedContexts.FootballMatch.Configuration
{
    using Domain.BoundedContexts.FootballMatch.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FootballMatchDBConfiguration : IEntityTypeConfiguration<FootballMatchEntity>
    {
        public void Configure(EntityTypeBuilder<FootballMatchEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.CreatedFrom)
                .IsRequired();

            builder
                .Property(c => c.CreatedOn)
                .IsRequired();

            builder
                .Property(c => c.HomeTeamId)
                .IsRequired();

            builder
              .HasOne(c => c.HomeTeam)
              .WithMany()
              .HasForeignKey(c => c.HomeTeamId)
              .OnDelete(DeleteBehavior.Cascade); // related entity will soft delete only. In real project will set to Restrict || SetNull

            builder
                .Property(c => c.HomeGoals)
                .IsRequired();

            builder
                .Property(c => c.GuestTeamId)
                .IsRequired();

            builder
                .HasOne(c => c.GuestTeam)
                .WithMany()
                .HasForeignKey(c => c.GuestTeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(c => c.GuestGoals)
                .IsRequired();

        }
    }
}
