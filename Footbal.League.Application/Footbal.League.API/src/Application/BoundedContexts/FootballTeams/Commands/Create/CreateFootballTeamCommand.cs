namespace Application.BoundedContexts.FootballTeams.Commands.Create
{
    using Application.Common;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Domain.BoundedContexts.FootballTeam.Factories;
    using Domain.BoundedContexts.FootbalTeam.Repositories;
    using MediatR;

    public class CreateFootballTeamCommand : IRequest<Result<Guid>>
    {
        public required string Name { get; set; } = default!;
        public string? Description { get; set; }


        public class CreateFootballTeamHandler(
            ICurrentUser currentUser,
            IFootballTeamFactory teamFactory,
            IFootballTeamsDomainRepository teamsRepository
            )
            : IRequestHandler<CreateFootballTeamCommand, Result<Guid>>
        {
            public async Task<Result<Guid>> Handle(CreateFootballTeamCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var teamEntity = teamFactory
                          .WithCreatedFrom(currentUser.UserIdAsGuid())  // Add authorization 
                          .WithName(request.Name)
                          .WithDescription(request.Description)
                          .Build();

                    var teamId = await teamsRepository.CreateTeamAsync(teamEntity);

                    return teamId;
                }
                catch (InvalidFootballTeamException)
                {
                    throw;
                }
                catch (Exception)
                {
                    //todo log
                    throw new Exception("Unable to create Football team!");
                }
            }
        }
    }
}
