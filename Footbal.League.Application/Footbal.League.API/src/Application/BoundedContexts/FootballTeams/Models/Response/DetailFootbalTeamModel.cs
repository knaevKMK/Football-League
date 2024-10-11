namespace Application.BoundedContexts.FootballTeams.Models.Response
{
    public class DetailFootbalTeamModel
    {
        public string TeamId { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
    }
}
