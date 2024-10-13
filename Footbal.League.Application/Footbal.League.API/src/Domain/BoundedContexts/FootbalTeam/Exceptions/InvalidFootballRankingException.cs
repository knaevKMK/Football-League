namespace Domain.BoundedContexts.FootbalTeam.Exceptions
{

    using Domain.Common;

    public class InvalidFootballRankingException : BaseDomainException
    {
        public InvalidFootballRankingException() : base() { }

        public InvalidFootballRankingException(string error)
        {
            Error = error;
        }
    }
}
