namespace Application.BoundedContexts.FootballTeams.Commands
{

    using Application.Common;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.BoundedContexts.FootbalTeam.Repositories;
    using MediatR;

    public class UpdateFootballCommand : IRequest<Result<bool>>
    {


        #region Props 
        public Guid? TeamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        #endregion

        public class UpdateFootballHandler(
            ICurrentUser currentUser,
            IFootballTeamsDomainRepository teamRepository)
            : IRequestHandler<UpdateFootballCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(UpdateFootballCommand request, CancellationToken cancellationToken)
            {
                FootballTeamEntity entity = await teamRepository.FindTeamByIdAsync(request.TeamId!.Value, CancellationToken.None);

                entity.Update(currentUser.UserIdAsGuid(), request.Name, request.Description);

                await teamRepository.UpdataTeamAsync(entity);

                return true;
            }
        }
    }
}
