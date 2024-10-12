namespace Infrastructure.BoundedContexts.FootballTeam.Repositories
{

    #region Usings
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Application.BoundedContexts.FootballTeams;
    using Application.BoundedContexts.FootballTeams.Models.Response;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Infrastructure.Common.Persistence;
    #endregion

    internal class FootballTeamRepository(IFootballTeamDbContext db, IMapper mapper) : DataRepository<IFootballTeamDbContext, FootballTeamEntity>(db)
        , IFootbalTeamsQueryRepository
    {
        public async Task<DetailFootbalTeamModel> DetailsTeamAsync(Guid teamId, CancellationToken cancellationToken)
        {

            return await Data.FootballTeams
                 .Where(team => team.Id == teamId)
                 .ProjectTo<DetailFootbalTeamModel>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(cancellationToken)
                 ?? throw new InvalidFootballTeamException("Team was not found");
        }

        public async Task<FootballTeamsListModel> ListTeamsAsync(CancellationToken cancellationToken)
        {
            return new FootballTeamsListModel
            {
                FootballTeams = await Data.FootballTeams
                                               // .Where about filter condition 
                                               .OrderByDescending(x => x.CreatedOn)
                                               .ProjectTo<FootballTeamsShortModel>(mapper.ConfigurationProvider)
                                               //.Take  get limited count of items (pageItems)
                                               //.Skip  prev preview items (pages * pageItems)
                                               .ToListAsync(cancellationToken)
            };
        }
    }
}
