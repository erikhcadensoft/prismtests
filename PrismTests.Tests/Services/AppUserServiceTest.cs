using PrismTests.Dtos;
using PrismTests.Interfaces;
using PrismTests.Services;
using System.Threading.Tasks;
using NUnit.Framework;
using PrismTests.Services;
using System;

namespace PrismTests.Tests.Services
{
    public class AppUserServiceTest : ServiceTestBase
    {
        public AppUserServiceTest()
        {
            RegisterType<AppUserService>();
        }

        [Test]
        public async Task GetAllUsersReturnsAllUsersFromApi()
        {
            var userService = ResolveType<AppUserService>();
            var appUsers = await userService.GetUsers();
            Assert.AreEqual(5, appUsers.Length);
        }

        [Test]
        public async Task UpdateUserReturnsUpdatedUserFromApi()
        {
            var userService = ResolveType<AppUserService>();
            Guid userId = new Guid("84291c0e-4b8d-42f5-8a19-b48ceb4d9a34");

            var user = await userService.GetUser(userId);
            var updatedUser = await userService.UpdateUser(user);

            Assert.IsNotNull(updatedUser);
        }

        [Test]
        public async Task UpdateUserHasUpdatedUser()
        {
            var userService = ResolveType<AppUserService>();
            Guid userId = new Guid("84291c0e-4b8d-42f5-8a19-b48ceb4d9a34");

            var saveUser = await userService.GetUser(userId);
            var updateUser = await userService.GetUser(userId);
            updateUser.LastName = "ChangeLast";

            var response = await userService.UpdateUser(updateUser);
            var verifyUser = await userService.GetUser(userId);

            Assert.AreEqual(saveUser.Id, verifyUser.Id);
            Assert.AreNotEqual(saveUser.LastName, verifyUser.LastName);
        }
    }
}
