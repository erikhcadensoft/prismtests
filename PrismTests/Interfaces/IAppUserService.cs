using System;
using System.Threading.Tasks;
using PrismTests.Dtos;

namespace PrismTests.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUserDto[]> GetUsers();
        Task<AppUserDto> GetUser(Guid userId);
        Task<AppUserDto> CreateUser(AppUserDto appUser);
        Task<AppUserDto> UpdateUser(AppUserDto appUser);
        Task<bool> DeleteUser(Guid userId);
    }
}
