using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EduCore.Application.Abstractions.Services
{
    public class BaseService
    {
        protected readonly Guid UserId;
        private readonly IHttpContextAccessor _accessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
            => _accessor = httpContextAccessor;
        private Guid GetUserId()
        {
            var user =  _accessor.HttpContext?.User;
            var claimValue = user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? user?.FindFirst("sub")?.Value;
            return Guid.TryParse(claimValue, out var userId) ? userId : Guid.Empty;
        }
    }
}
