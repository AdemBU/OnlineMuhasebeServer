using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntites;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task<Company?> GetCompanyByName(string name);
        Task MigrationCompanyDatabase();
    }
}
