using AutoMapper;
using Prism.Ioc;
using PrismTests.Dtos;
using PrismTests.Interfaces;

namespace PrismTests
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(IMapper), ConfigureMapper());
        }

        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppUserDto, IAppUser>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
