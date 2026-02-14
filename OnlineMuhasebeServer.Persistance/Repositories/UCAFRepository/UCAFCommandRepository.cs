using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.IUCAFRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.UCAFRepository
{
    public sealed class UCAFCommandRepository : CommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}
