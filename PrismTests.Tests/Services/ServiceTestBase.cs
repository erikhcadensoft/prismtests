using Ease.NUnit.Unity.PrismForms;
using PrismTests.Interfaces;

namespace PrismTests.Tests.Services
{
    public class ServiceTestBase : AppTestBase
    {
        public ServiceTestBase()
        {
            RegisterType<IHttpMessageHandlerFactory, MockApiHttpHandlerFactory>();
        }
    }
}
