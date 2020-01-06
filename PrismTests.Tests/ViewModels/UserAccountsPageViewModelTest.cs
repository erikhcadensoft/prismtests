using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Prism.Navigation;
using PrismTests.Interfaces;
using PrismTests.ViewModels;

namespace PrismTests.Tests.ViewModels
{
    public class UserAccountsPageViewModelTest : ViewModelTestBase
    {
        public UserAccountsPageViewModelTest()
        {
            RegisterType<UserAccountsPageViewModel>();
        }

        [Test]
        public async Task IAppUserRepositoryGetUsersIsCalledOnNavigation()
        {
            //var vm = await ResolveAndCallOnNavigatedToAsync<UserAccountsPageViewModel>(NavigationMode.New);
            GetMock<IAppUserRepository>().Verify(u => u.GetUsers(), Times.Once);
        }
    }
}
