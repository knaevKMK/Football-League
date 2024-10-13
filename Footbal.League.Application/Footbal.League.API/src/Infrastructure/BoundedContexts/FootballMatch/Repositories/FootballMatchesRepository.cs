
using Application.BoundedContexts.FootballMatches;
using Application.BoundedContexts.FootballMatches.Models.Response;
using Application.BoundedContexts.FootballTeams.Models.Response;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.BoundedContexts.FootballMatch.Entities;
using Domain.BoundedContexts.FootballMatch.Repositories;
using Domain.BoundedContexts.FootballTeam.Exceptions;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BoundedContexts.FootballMatch.Repositories
{
    internal class FootballMatchesRepository(IFootballMatchDbContext db, IMapper mapper) : DataRepository<IFootballMatchDbContext, FootballMatchEntity>(db),
        IFootballMatchesDomainRepository,
        IFootbalMatchesQueryRepository
    {
        public async Task<Guid> CreateAsync(FootballMatchEntity entity)
        {
            var entry = await Data.FootballMatches.AddAsync(entity);

            await Data.SaveChangesAsync();

            return entry.Entity.Id;
        }

        public async Task<DetailMatchTeamModel> DetailsMatchAsync(Guid teamId, CancellationToken cancellationToken)
        {
            return await Data.FootballMatches
                 .Where(team => team.Id == teamId)
                 .ProjectTo<DetailMatchTeamModel>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(cancellationToken)
                 ?? throw new InvalidFootballTeamException("Match was not found");
        }

        public async Task<FootballMatchesListModel> ListMatchesAsync(CancellationToken cancellationToken)
        {
            return new FootballMatchesListModel
            {
                FootballMatches = await Data.FootballMatches
                                               // .Where about filter condition 
                                               .OrderByDescending(x => x.CreatedOn)
                                               .ProjectTo<FootballMatchesShortModel>(mapper.ConfigurationProvider)
                                               //.Take  get limited count of items (pageItems)
                                               //.Skip  prev preview items (pages * pageItems)
                                               .ToListAsync(cancellationToken)
            };
        }
    }
}
