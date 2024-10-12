namespace Application.Common.Contracts
{
    public interface ICurrentUser
    {
        void UpdateUserId(string userId);
        string UserId();
        Guid UserIdAsGuid();
    }
}
