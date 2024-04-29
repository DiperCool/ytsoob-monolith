using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ytsoob.Shared.Securiry;

public class CurrentUserService : ICurrentUserService
{
    private readonly ILogger<CurrentUserService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, ILogger<CurrentUserService> logger)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string? UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            return userId;
        }
    }

    public bool IsAuthenticated
    {
        get
        {
            var isAuthenticated = _httpContextAccessor.HttpContext?.User?.Identities?.FirstOrDefault()?.IsAuthenticated;
            return isAuthenticated.HasValue && isAuthenticated.Value;
        }
    }
}
