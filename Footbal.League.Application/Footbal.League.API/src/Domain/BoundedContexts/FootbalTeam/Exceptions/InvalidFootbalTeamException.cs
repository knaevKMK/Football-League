namespace Domain.BoundedContexts.FootbalTeam.Exceptions
{

    using Domain.Common;

    public class InvalidFootbalTeamException : BaseDomainException
    {
        public InvalidFootbalTeamException()
        {
        }

        public InvalidFootbalTeamException(string error)
        {
            this.Error = error;
        }
    }
}
