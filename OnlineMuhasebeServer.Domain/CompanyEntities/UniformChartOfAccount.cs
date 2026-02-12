using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; } // Ana Grup = A, Grup = G, Muavin = M
        public string CompanyId { get; set; }
    }
}
