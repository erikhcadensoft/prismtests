using System;
using System.Threading.Tasks;
using PrismTests.Dtos;
using PrismTests.Interfaces;

namespace PrismTests.Services
{
    public class AppUserService : ApiServiceBase, IAppUserService
    {
        public AppUserService(IHttpMessageHandlerFactory messageHandlerFactory)
            : base(messageHandlerFactory)
        {
        }

        public async Task<AppUserDto[]> GetUsers()
        {
            var result = await ApiGetData<AppUserDto[]>(ApiEndpoints.GetUsersUri());
            return result.Data;
        }

        public async Task<AppUserDto> GetUser(Guid userId)
        {
            var result = await ApiGetData<AppUserDto>(ApiEndpoints.GetUserUri(userId));
            return result.Data;
        }

        public async Task<AppUserDto> CreateUser(AppUserDto appUser)
        {
            var result = await ApiPostData<AppUserDto>(ApiEndpoints.PostUserUri(), appUser);
            return result.Data;
        }

        public async Task<AppUserDto> UpdateUser(AppUserDto appUser)
        {
            var result = await ApiPutData<AppUserDto>(ApiEndpoints.PostUserUri(), appUser);
            return result.Data;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var result = await ApiDelete<bool>(ApiEndpoints.DeleteUserUri(userId));
            return result.Data;
        }
    }
}
