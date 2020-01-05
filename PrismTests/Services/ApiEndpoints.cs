using System;
namespace PrismTests.Services
{
    public static class ApiEndpoints
    {
        private static string protocol = "https";
        private static string host = "dev.cadensoft.com";

        private static Uri _baseUri;
        private static Uri BaseUri => _baseUri ?? (_baseUri = new Uri($"{protocol}://{host}/api/"));

        public static Uri GetUsersUri() => new Uri(BaseUri, $"users");
        public static Uri GetUserUri(Guid userId) => new Uri(BaseUri, $"users/{userId}");
        public static Uri PostUserUri() => new Uri(BaseUri, $"users/user");
        public static Uri DeleteUserUri(Guid userId) => new Uri(BaseUri, $"users/{userId}");
    }
}
