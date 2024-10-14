namespace Infrastructure.Common.Persistence
{

    #region Usings
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballMatch.Entities;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.BoundedContexts.FootbalTeam.Entities;
    using Domain.Common.Models;
    using Infrastructure.BoundedContexts.FootballMatch;
    using Infrastructure.BoundedContexts.FootballTeam;
    using Infrastructure.Common.Events;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    #endregion

    internal class FootballAppDbContext : DbContext,
        IFootballTeamDbContext,
        IFootballMatchDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;
        private readonly ICurrentUser _currentUser;

        public FootballAppDbContext(
            DbContextOptions<FootballAppDbContext> options,
            IEventDispatcher eventDispatcher,
            ICurrentUser currentUser)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
            _currentUser = currentUser;
        }

        #region Entities
        public DbSet<FootballTeamEntity> FootballTeams { get; set; } = default!;
        public DbSet<FootballMatchEntity> FootballMatches { get; set; } = default!;
        public DbSet<FootballRankingEntity> Ranks { get; set; } = default!;
        #endregion

        #region Overrides
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            OverrideDeleteEntities();
            OverrideUpdateEntities();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        #endregion

        #region Private Methods
        private void OverrideDeleteEntities()
        {
            var softDeletableEntitiesOnDelete = ChangeTracker.Entries<IDeletable>()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            foreach (var entity in softDeletableEntitiesOnDelete)
            {
                entity.State = EntityState.Modified;
                entity.Entity.Delete(_currentUser.UserIdAsGuid());
            }
        }

        private void OverrideUpdateEntities()
        {
            var mutableEntitiesOnModification = ChangeTracker.Entries<IMutable>()
                .Where(e => e.State == EntityState.Modified)
                .ToList();

            foreach (var entity in mutableEntitiesOnModification)
            {
                entity.Entity.UpdateModifiedFrom(_currentUser.UserIdAsGuid());
            }
        }
        #endregion
    }
}
