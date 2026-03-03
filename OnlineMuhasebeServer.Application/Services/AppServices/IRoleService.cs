using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CraeteRole;
using OnlineMuhasebeServer.Domain.AppEntites.Identity;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task UpdateAsync(AppRole appRole);
        Task DeleteAsync(AppRole appRole);
        Task<IList<AppRole>> GetAllRoleAsync();
        Task<AppRole> GetById(string id);
        Task<AppRole> GetByCode(string code);

    }
}
