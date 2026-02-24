using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebeServer.Domain.AppEntites.Identity
{
    public sealed class AppRole : IdentityRole<string>
    {
        public string Code { get; set; }
    }
}
