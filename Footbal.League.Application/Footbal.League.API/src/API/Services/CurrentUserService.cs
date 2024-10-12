namespace API.Services
{

    using System;
    using System.Security.Claims;
    using Application.Common.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUser
    {
        private string userId;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            this.userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            if (user == null)
            {
                // throw new UnauthorizedAccessException("This request does not have an authenticated user.");
            }
        }

        public string UserId() => this.userId;

        public Guid UserIdAsGuid() => Guid.Parse(userId);

        public void UpdateUserId(string userId)
        {
            this.userId = userId;
        }
    }
}
