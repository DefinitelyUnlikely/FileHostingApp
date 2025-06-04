using System.Security.Claims;

namespace Backend.Services;

public interface IAuthService
{
    string? UserId { get; }
    bool UserIsAdmin { get; }
}

/// <summary>
/// Uses the HttpContext to return user NameIdentifier or if in specified role Admin. 
/// </summary>
/// <param name="accessor"></param>
public class UserAuthService(IHttpContextAccessor accessor) : IAuthService
{
    public string? UserId => accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    public bool UserIsAdmin => accessor.HttpContext?.User?.IsInRole("Admin") ?? false;
}

