namespace Valit.AspNetCore.Tests.IntegrationApp.Validators
{
    public static class ErrorMessages
    {
        public static string EmptyId => "Id is empty";
        public static string RequiredEmail => "Email is required";
        public static string InvalidEmail => "Email is invalid";
        public static string TooSmallAge => "Age is too small";
    }
}