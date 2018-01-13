using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RestEase;
using Valit.AspNetCore.Tests.Http;
using Valit.AspNetCore.Tests.IntegrationApp;
using Xunit;

namespace Valit.AspNetCore.Tests
{
    public class FailFast_Integration_Tests
    {


#region ARRANGE

        private readonly TestServer _server;
        private readonly IValitIntegrationAppApi _api;

        public FailFast_Integration_Tests()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<FailFastStartup>();

            _server = new TestServer(webHostBuilder);
            _api = RestClient.For<IValitIntegrationAppApi>("http://localhost:5000");
        }

#endregion        
    }
}
