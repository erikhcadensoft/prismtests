using PrismTests.Dtos;
using PrismTests.Interfaces;
using PrismTests.Services;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace PrismTests.Tests.Services
{
    public class MockApiHttpHandlerFactory : IHttpMessageHandlerFactory
    {
        public MockHttpMessageHandler MessageHandler { get; set; }

        private TestApiData Data { get; }

        public MockApiHttpHandlerFactory()
        {
            Data = new TestApiData();
            MessageHandler = new MockHttpMessageHandler();
            SetupUsersApi();
        }

        private void SetupUsersApi()
        {
            MessageHandler.When(HttpMethod.Get,
                ApiEndpoints.GetUsersUri().ToString())
                .Respond("application/json", JsonConvert.SerializeObject(Data.AppUsers));

            MessageHandler.When(HttpMethod.Get,
                $"{ApiEndpoints.GetUsersUri()}/*")
                .Respond(request =>
                {
                    var id = GetIdFromUrl(request);
                    var user = Data.AppUsers.FirstOrDefault(u => u.Id == id);

                    return CreateJsonResponse(user);
                });

            MessageHandler.When(HttpMethod.Put,
                ApiEndpoints.PostUserUri().ToString())
                .Respond(async request =>
                {
                    var userRequest = await GetObjectFromRequest<AppUserDto>(request);
                    var currentUser = Data.AppUsers.FirstOrDefault(u => u.Id == userRequest.Id);

                    Data.AppUsers.Remove(currentUser);
                    Data.AppUsers.Add(userRequest);

                    return CreateJsonResponse(userRequest);
                });
        }

        private static Guid GetIdFromUrl(HttpRequestMessage request)
        {
            var idSegment = request.RequestUri.Segments.Length - 1;
            Guid.TryParse(request.RequestUri.Segments[idSegment], out var id);
            return id;
        }

        private static async Task<T> GetObjectFromRequest<T>(HttpRequestMessage request)
        {
            var requestJson = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(requestJson);
        }

        private HttpResponseMessage CreateJsonResponse(object data)
        {
            if (data == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }

            var json = JsonConvert.SerializeObject(data);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };
        }

        public HttpMessageHandler GetHttpMessageHandler()
        {
            return MessageHandler;
        }
    }
}