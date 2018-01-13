using System;

namespace Valit.AspNetCore.Tests.IntegrationApp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public uint Age { get; set; }
    }
}