using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Valit.AspNetCore.Tests.IntegrationApp.Models;

namespace Valit.AspNetCore.Tests.IntegrationApp.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        [HttpPost("Validate")]
        public IEnumerable<string> Validate([FromBody] UserModel user)
            => ModelState.IsValid ? 
                  Enumerable.Empty<string>()
                : ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
    }
}