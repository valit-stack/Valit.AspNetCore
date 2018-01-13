using System.Collections.Generic;
using Valit.AspNetCore.Tests.IntegrationApp.Models;

namespace Valit.AspNetCore.Tests.Http
{
    public interface IValitIntegrationAppApi
    {
         IEnumerable<string> Validate(UserModel user);
    }
}