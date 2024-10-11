namespace Domain.BoundedContexts.FootbalTeam.Exceptions
{

    using Domain.Common;

    public class InvalidFootbalException : BaseDomainException
    {
        public InvalidFootbalException()
        {
        }

        public InvalidFootbalException(string error)
        {
            this.Error = error;
        }
    }
}
