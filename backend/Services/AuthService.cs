using System.Security.Claims;

namespace Backend.Services;

public interface IAuthService
{
    string? UserId { get; }
    bool IsAdmin { get; }
}

public class AuthService(IHttpContextAccessor accessor) : IAuthService
{
    public string? UserId => accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    public bool IsAdmin => accessor.HttpContext?.User?.IsInRole("Admin") ?? false;

}