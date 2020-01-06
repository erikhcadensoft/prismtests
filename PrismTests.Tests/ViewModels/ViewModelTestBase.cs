using Moq;
using PrismTests.Dtos;
using PrismTests.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrismTests.Tests.ViewModels
{
    public class ViewModelTestBase : AppTestBase
    {
        protected Action<Mock<IAppUserRepository>> onIAppUserRepositoryCreated;

        public ViewModelTestBase()
        {
            RegisterMockType(() => onIAppUserRepositoryCreated);

            RegisterPerTestSetup(() =>
            {
                onIAppUserRepositoryCreated = IAppUserRepositoryDefaultSetup;
            });
        }

        private void IAppUserRepositoryDefaultSetup(Mock<IAppUserRepository> mock)
        {
            mock.Setup(r => r.GetUsers())
                .Returns(Task.FromResult(
                    Mapper().Map<AppUserDto[], IAppUser[]>(
                        ResolveType<TestApiData>().AppUsers.ToArray())));

            mock.Setup(r => r.GetUser(It.IsAny<Guid>()))
                .Returns<Guid>(id => Task.FromResult(
                    Mapper().Map<AppUserDto, IAppUser>(
                        ResolveType<TestApiData>().AppUsers.FirstOrDefault(u => u.Id == id))));

            mock.Setup(r => r.CreateUser(It.IsAny<IAppUser>()))
                .Returns<AppUserDto>(request =>
                {
                    var testData = ResolveType<TestApiData>();
                    var userDto = testData.CreateAppUserDto(Guid.NewGuid(), request.FirstName, request.LastName, request.Email, request.AcceptsTermsAndConditions);

                    var user = Mapper().Map<AppUserDto, IAppUser>(userDto);
                    return Task.FromResult(user);
                });
        }
    }
}
