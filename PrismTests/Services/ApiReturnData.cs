using System.Net;

namespace PrismTests.Services
{
    public class ApiReturnData<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
