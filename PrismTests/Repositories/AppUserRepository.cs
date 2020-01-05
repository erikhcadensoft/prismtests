using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using PrismTests.Dtos;
using PrismTests.Interfaces;

namespace PrismTests.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        public IMapper Mapper { get; }
        public IAppUserService AppUserService { get; }

        public AppUserRepository(IMapper mapper, IAppUserService appUserService)
        {
            Mapper = mapper;
            AppUserService = appUserService;
        }

        public async Task<IAppUser[]> GetUsers()
        {
            var users = await AppUserService.GetUsers();
            return Mapper.Map<AppUserDto[], IAppUser[]>(users);
        }

        public async Task<IAppUser> GetUser(Guid userId)
        {
            var user = await AppUserService.GetUser(userId);
            return Mapper.Map<AppUserDto, IAppUser>(user);
        }

        public async Task<IAppUser> CreateUser(IAppUser appUser)
        {
            try
            {
                var requestDto = Mapper.Map<IAppUser, AppUserDto>(appUser);
                var responseDto = await AppUserService.CreateUser(requestDto);
                return Mapper.Map<AppUserDto, IAppUser>(responseDto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IAppUser> UpdateUser(IAppUser appUser)
        {
            var requestDto = Mapper.Map<IAppUser, AppUserDto>(appUser);
            var responseDto = await AppUserService.UpdateUser(requestDto);
            return Mapper.Map<AppUserDto, IAppUser>(responseDto);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var success = await AppUserService.DeleteUser(userId);
            return success;
        }
    }
}
