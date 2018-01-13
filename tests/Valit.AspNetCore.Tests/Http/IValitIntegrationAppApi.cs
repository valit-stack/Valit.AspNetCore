using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using Valit.AspNetCore.Tests.IntegrationApp.Models;

namespace Valit.AspNetCore.Tests.Http
{
    public interface IValitIntegrationAppApi
    {
        [Post("/api/Users/Validate")]
        Task<IEnumerable<string>> ValidateAsync([Body] UserModel user);
    }
}