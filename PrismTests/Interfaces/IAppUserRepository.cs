using System;
using System.Threading.Tasks;

namespace PrismTests.Interfaces
{
    public interface IAppUserRepository
    {
        Task<IAppUser[]> GetUsers();
        Task<IAppUser> GetUser(Guid userId);
        Task<IAppUser> CreateUser(IAppUser appUser);
        Task<IAppUser> UpdateUser(IAppUser appUser);
        Task<bool> DeleteUser(Guid userId);
    }
}
