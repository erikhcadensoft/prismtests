using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismTests.Interfaces;

namespace PrismTests.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService, IViewModelManager viewModelManager)
            : base(navigationService, pageDialogService, deviceService, viewModelManager)
        {
            try
            {
                Title = "Hi From Prism";
                AppUser = _viewModelManager.UpdateOrCreatetUser(null);
            }
            catch (Exception ex)
            {
                // TODO: Logger.LogError(ex);
            }
        }

    }
}
