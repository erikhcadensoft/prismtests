using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismTests.Interfaces;
using PrismTests.Models;
using PrismTests.Services;
using PrismTests.ViewModels;
using PrismTests.Views;
using Xamarin.Forms;

namespace PrismTests
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer):base(platformInitializer)
        {

        }
        
        protected override void OnInitialized()
        {
            InitializeComponent();
            var result = NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISettings, Settings>();
            containerRegistry.RegisterSingleton<IViewModelManager, ViewModelManager>();
            containerRegistry.RegisterSingleton<IAppUserService, AppUserService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
