namespace Application.BoundedContexts.FootballTeams.Models.Response
{
    public class FootballTeamsListModel
    {
        public ICollection<FootballTeamsShortModel> FootballTeams { get; set; } = new List<FootballTeamsShortModel>();
    }

    public class FootballTeamsShortModel
    {
        public string TeamId { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
