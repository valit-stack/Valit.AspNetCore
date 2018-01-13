using System.Collections.Generic;
using System.Threading.Tasks;
using Valit.AspNetCore.Tests.IntegrationApp.Models;

namespace Valit.AspNetCore.Tests.Http
{
    public interface IValitIntegrationAppApi
    {
         Task<IEnumerable<string>> ValidateAsync(UserModel user);
    }
}