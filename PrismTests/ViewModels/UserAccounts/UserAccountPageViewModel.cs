using System;
using System.Threading;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismTests.Helpers;
using PrismTests.Interfaces;
using PrismTests.Resources;

namespace PrismTests.ViewModels
{
    public class UserAccountPageViewModel : ViewModelBase
    {
        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand => _submitCommand ?? (_submitCommand = new DelegateCommand(async () => await ExecuteSubmitCommandAsync()));

        #region Properties

        /// <summary>
        /// The cancellation token source.
        /// </summary>
        /// <remarks>
        /// We will need a CancellationTokenSource so we can cancel the async calls.
        /// </remarks>
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        #endregion

        public UserAccountPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService, IViewModelManager viewModelManager)
            : base(navigationService, pageDialogService, deviceService, viewModelManager)
        {
            try
            {
                Title = AppResources.UserAccount_PageTitle;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            try
            {
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            try
            {
                base.OnNavigatedFrom(parameters);
                CancelTask(_cts);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                _cts = CancellationTokenHelper.SetupCancellationToken(_cts);

                switch (parameters.GetNavigationMode())
                {
                    case NavigationMode.Back:
                        // TODO: Handle any tasks that should occur only when navigated back to
                        break;
                    case NavigationMode.New:
                        IsBusy = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        #region Command Handlers

        private async Task ExecuteSubmitCommandAsync()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(4000);
            }

            catch (Exception ex)
            {
                LogError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Public Methods


        #endregion

        #region Private Methods


        #endregion
    }
}
