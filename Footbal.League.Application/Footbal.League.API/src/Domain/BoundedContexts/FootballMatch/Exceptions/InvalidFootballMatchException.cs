namespace Domain.BoundedContexts.FootballMatch.Exceptions
{

    using Domain.Common;

    public class InvalidFootballMatchException : BaseDomainException
    {
        public InvalidFootballMatchException(): base(){}

        public InvalidFootballMatchException(string error)
        {
            this.Error = error;
        }
    }
}
