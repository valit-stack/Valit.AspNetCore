using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RestEase;
using Shouldly;
using Valit.AspNetCore.Tests.Http;
using Valit.AspNetCore.Tests.IntegrationApp;
using Valit.AspNetCore.Tests.IntegrationApp.Models;
using Valit.AspNetCore.Tests.IntegrationApp.Validators;
using Xunit;

namespace Valit.AspNetCore.Tests
{
    public class FailFast_Integration_Tests
    {
        [Fact]
        public async Task Api_Returns_Empty_Collection_If_Valid_Model_Is_Given()
        {
            var validUserModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = "user@test.com",
                Age = 24
            };

            var errors = await _api.ValidateAsync(validUserModel);

            errors.ShouldBeEmpty();
        }

        [Fact]
        public async Task Api_Returns_One_Element_Collection_If_Invalid_Model_Is_Given()
        {
            var invalidUserModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = "user_test_com",
                Age = 24
            };

            var errors = (await _api.ValidateAsync(invalidUserModel)).ToArray();

            errors.Length.ShouldBe(1);
            errors.First().ShouldBe(ErrorMessages.InvalidEmail);
        }


#region ARRANGE

        private readonly TestServer _server;
        private readonly IValitIntegrationAppApi _api;

        public FailFast_Integration_Tests()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<FailFastStartup>();

            _server = new TestServer(webHostBuilder);
            _api = RestClient.For<IValitIntegrationAppApi>(_server.CreateClient());
        }

#endregion        
    }
}
