using System.Net.Http;

namespace PrismTests.Interfaces
{
    public interface IHttpMessageHandlerFactory
    {
        HttpMessageHandler GetHttpMessageHandler();
    }
}
