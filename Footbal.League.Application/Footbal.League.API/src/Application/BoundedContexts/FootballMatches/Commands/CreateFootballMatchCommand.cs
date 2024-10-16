﻿namespace Application.BoundedContexts.FootballMatches.Commands
{

    using Application.Common;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballMatch.Exceptions;
    using Domain.BoundedContexts.FootballMatch.Repositories;
    using Domain.BoundedContexts.FootballTeam.Factories;
    using Domain.BoundedContexts.FootbalTeam.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateFootballMatchCommand : IRequest<Result<Guid>>
    {
        #region props
        public Guid HomeTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public Guid GuestTeamId { get; set; }
        public int GuestTeamGoals { get; set; }
        #endregion

        public class CreateFootballMatchHandler(
                                            ICurrentUser currentUser,
                                            IFootballMatchFactory matchFactory,
                                            IFootballMatchesDomainRepository matchesRepository,
                                            IFootballTeamsDomainRepository footballTeamsDomainRepository
                                            )
            : IRequestHandler<CreateFootballMatchCommand, Result<Guid>>
        {
            public async Task<Result<Guid>> Handle(CreateFootballMatchCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = matchFactory
                                           .WithCreatedFrom(currentUser.UserIdAsGuid())
                                           .WithHomeTeam(request.HomeTeamId)
                                           .WithHomeTeamGoals((byte)request.HomeTeamGoals)
                                           .WithGuestTeam(request.GuestTeamId)
                                           .WithGuestTeamGoals((byte)request.GuestTeamGoals)
                                           .Build();

                    var matchId = await matchesRepository.CreateAsync(entity);


                    //ToDo impl Rank(Transact-SQL)
                    await footballTeamsDomainRepository.UpdateRankAsync(matchId, request.HomeTeamId, (byte)request.HomeTeamGoals, request.GuestTeamId, (byte)request.GuestTeamGoals);

                    return matchId;
                }
                catch (InvalidFootballMatchException)
                {
                    throw;
                }
                catch (Exception)
                {

                    throw new Exception("Unable to create match");
                }
            }
        }
    }
}
