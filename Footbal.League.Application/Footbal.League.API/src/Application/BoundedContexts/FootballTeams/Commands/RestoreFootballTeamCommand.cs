namespace Application.BoundedContexts.FootballTeams.Commands
{

    using Application.Common.Contracts;
    using Application.Common;
    using Domain.BoundedContexts.FootbalTeam.Repositories;
    using MediatR;

    public class RestoreFootballTeamCommand : IRequest<Result<bool>>
    {
        public Guid TeamId { get; set; }
        public class RestoreFootballTeamHandler(
            ICurrentUser currentUser,
            IFootballTeamsDomainRepository teamRepository
            ) : IRequestHandler<RestoreFootballTeamCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(RestoreFootballTeamCommand request, CancellationToken cancellationToken)
            {
                var teamEntity = await teamRepository.FindTeamByIdAsync(request.TeamId, cancellationToken);

                teamEntity.Restore(currentUser.UserIdAsGuid());

                await teamRepository.UpdataTeamAsync(teamEntity);

                return true;
            }
        }
    }
}
