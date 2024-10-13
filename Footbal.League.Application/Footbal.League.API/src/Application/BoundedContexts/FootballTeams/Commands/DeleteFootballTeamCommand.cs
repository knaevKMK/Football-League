namespace Application.BoundedContexts.FootballTeams.Commands
{

    using Application.Common;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootbalTeam.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteFootballTeamCommand : IRequest<Result<bool>>
    {
        public Guid TeamId { get; set; }
        public class DeleteFootballTeamHandler(
            ICurrentUser currentUser,
            IFootballTeamsDomainRepository teamRepository
            ) : IRequestHandler<DeleteFootballTeamCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(DeleteFootballTeamCommand request, CancellationToken cancellationToken)
            {
                var teamEntity = await teamRepository.FindTeamByIdAsync(request.TeamId, cancellationToken);

                teamEntity.Delete(currentUser.UserIdAsGuid());

                await teamRepository.UpdataTeamAsync(teamEntity);

                return true;
            }
        }
    }
}
