using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PrismTests.Dtos;
using PrismTests.Interfaces;
using PrismTests.Models;
using PrismTests.Repositories;

namespace PrismTests.Tests.Repositories
{
    public class AppUserRepositoryTest : AppTestBase
    {
        private Action<Mock<IAppUserService>> onMockIAppUserServiceCreated;

        public AppUserRepositoryTest()
        {
            RegisterMockType(() => onMockIAppUserServiceCreated);
            RegisterType<AppUserRepository>();
            RegisterType<TestApiData>();

            RegisterPerTestSetup(() =>
            {
                onMockIAppUserServiceCreated = IAppUserServiceDefaultSetup;
            });
        }

        private void IAppUserServiceDefaultSetup(Mock<IAppUserService> serviceMock)
        {
            serviceMock.Setup(s => s.GetUsers())
                .Returns(() => Task.FromResult(ResolveType<TestApiData>().AppUsers.Cast<AppUserDto>().ToArray()));

            serviceMock.Setup(s => s.GetUser(It.IsAny<Guid>()))
                .Returns<Guid>(id => Task.FromResult(ResolveType<TestApiData>().AppUsers.FirstOrDefault(x => x.Id == id)));

            serviceMock.Setup(s => s.CreateUser(It.IsAny<AppUserDto>()))
                .Returns<AppUserDto>(request =>
                {
                    var testData = ResolveType<TestApiData>();
                    var user = testData.CreateAppUserDto(new Guid(), request.FirstName, request.LastName, request.Email, request.AcceptsTermsAndConditions);
                    testData.AppUsers.Add(user);
                    return Task.FromResult(user);
                });
        }

        [Test]
        public async Task GetUsersReturnsAllUsersFromService()
        {
            var repo = ResolveType<AppUserRepository>();
            var allUsers = await repo.GetUsers();
            Assert.NotNull(allUsers);
            Assert.AreEqual(5, allUsers.Length);
        }

        [Test]
        public async Task GetUserReturnsUserByIdFromService()
        {
            Guid userId = new Guid("84291c0e-4b8d-42f5-8a19-b48ceb4d9a34");

            var repo = ResolveType<AppUserRepository>();
            var user = await repo.GetUser(userId);
            Assert.NotNull(user);
            Assert.AreEqual(userId, user.Id);
        }

        [Test]
        public async Task CreateUserReturnsUserFromApi()
        {
            var repo = ResolveType<AppUserRepository>();
            var user = (IAppUser)new AppUser
            {
                FirstName = "Test",
                LastName = "Create-Account",
                Email = "test.create-account@example.org",
                AcceptsTermsAndConditions = true
            };
            var newUser = await repo.CreateUser(user);
            var allUsers = await repo.GetUsers();

            Assert.NotNull(newUser);
            Assert.AreNotEqual(Guid.Empty, newUser.Id);
            Assert.That(allUsers.Any(a => a.Id == newUser.Id));
        }
    }
}
