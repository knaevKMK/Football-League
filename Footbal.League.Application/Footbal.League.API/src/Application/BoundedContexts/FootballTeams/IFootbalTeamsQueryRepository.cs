namespace Application.BoundedContexts.FootballTeams
{

    using Application.BoundedContexts.FootballTeams.Models.Response;

    public interface IFootbalTeamsQueryRepository
    {
        Task<FootballTeamsListModel> ListTeamsAsync(CancellationToken cancellationToken);
    }
}
