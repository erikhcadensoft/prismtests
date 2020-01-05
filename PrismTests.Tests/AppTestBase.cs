using AutoMapper;
using Ease.NUnit.Unity.PrismForms;

namespace PrismTests.Tests
{
    public class AppTestBase : PrismFormsTestBase
    {
        public AppTestBase()
        {
            RegisterTypeFactory(AutoMapperConfig.ConfigureMapper);
        }

        protected IMapper Mapper()
        {
            return ResolveType<IMapper>();
        }
    }
}
