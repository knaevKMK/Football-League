namespace Domain.BoundedContexts.FootballTeam.Exceptions
{

    using Domain.Common;

    public class InvalidFootballTeamException : BaseDomainException
    {
        public InvalidFootballTeamException()
        {
        }

        public InvalidFootballTeamException(string error)
        {
            this.Error = error;
        }
    }
}
