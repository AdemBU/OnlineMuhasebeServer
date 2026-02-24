using OnlineMuhasebeServer.Domain.AppEntites.Identity;

namespace OnlineMuhasebeServer.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user, IList<string> roles);
    }
}
