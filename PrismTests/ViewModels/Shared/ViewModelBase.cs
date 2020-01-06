using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Prism;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismTests.Helpers;
using PrismTests.Interfaces;
using PrismTests.Resources;

namespace PrismTests.ViewModels
{
    public class ViewModelBase : BindableBase, IActiveAware, INavigationAware, IDestructible, IConfirmNavigation, IConfirmNavigationAsync, IApplicationLifecycleAware, IPageLifecycleAware, INotifyPropertyChanged
    {
        //INavigatedAwareAsync
        #region Commands

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommmand));

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected IPageDialogService _pageDialogService { get; }

        protected IDeviceService _deviceService { get; }

        protected INavigationService _navigationService { get; }

        protected IViewModelManager _viewModelManager { get; }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService,
                             IDeviceService deviceService, IViewModelManager viewModelManager)
        {
            _pageDialogService = pageDialogService;
            _deviceService = deviceService;
            _navigationService = navigationService;
            _viewModelManager = viewModelManager;
        }

        public IAppUser AppUser { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Icon { get; set; }

        public bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private string _homeNavParam;
        public string HomeNavParam
        {
            get => _homeNavParam;
            set
            {
                SetProperty(ref _homeNavParam, value);
                RaisePropertyChanged(() => HomeNavParam);
            }
        }

        private string _swipeLeftParam;
        public string SwipeLeftParam
        {
            get => _swipeLeftParam;
            set
            {
                SetProperty(ref _swipeLeftParam, value);
                RaisePropertyChanged(() => SwipeLeftParam);
            }
        }

        private string _swipeRightParam;
        public string SwipeRightParam
        {
            get => _swipeRightParam;
            set
            {
                SetProperty(ref _swipeRightParam, value);
                RaisePropertyChanged(() => SwipeRightParam);
            }
        }

        public bool IsNotBusy { get; set; }

        public bool CanLoadMore { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        private void OnIsBusyChanged() => IsNotBusy = !IsBusy;

        private void OnIsNotBusyChanged() => IsBusy = !IsNotBusy;

        #region IActiveAware

        public bool IsActive { get; set; }

        public event EventHandler IsActiveChanged;

        private void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                OnIsActive();
            }
            else
            {
                OnIsNotActive();
            }
        }

        protected virtual void OnIsActive() { }

        protected virtual void OnIsNotActive() { }

        #endregion IActiveAware

        #region INavigationAware

        public virtual void Initialize(INavigationParameters parameters) { }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
        public virtual async void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual async void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        #endregion INavigationAware

        #region IDestructible

        public virtual void Destroy() { }

        #endregion IDestructible

        #region IConfirmNavigation

        public virtual bool CanNavigate(INavigationParameters parameters) => true;

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
            Task.FromResult(CanNavigate(parameters));

        #endregion IConfirmNavigation

        #region IApplicationLifecycleAware

        public virtual void OnResume() { }

        public virtual void OnSleep() { }

        #endregion IApplicationLifecycleAware

        #region IPageLifecycleAware

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        #endregion IPageLifecycleAware

        #region Command Handlers

        protected virtual async void ExecuteNavigateCommmand(string name)
        {
            IsBusy = true;
            try
            {
                // if user is navigating to the Dashboard or Product Overview page, we want to disable animations
                switch (name)
                {
                    // if user is navigating to the Dashboard, reset nav stack
                    case string a when a.Contains(AppConstants.Navigation.Dashboard):
                        var result = await _navigationService.NavigateAsync(name, null, true, false);
                        if (!result.Success)
                        {
                        }
                        break;
                    default:
                        result = await _navigationService.NavigateAsync(name);
                        if (!result.Success)
                        {

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        //public virtual void OnTimedEvent(object sender, ElapsedEventArgs e, Models.TimerType timerType) { }

        #region Protected Methods

        protected virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> p)
        {
            var memberExpression = (MemberExpression)p.Body;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }

        protected void CancelTask(CancellationTokenSource cts)
        {
            try
            {
                if (cts != null && cts.Token.CanBeCanceled) cts.Cancel();
            }
            catch (OperationCanceledException opCanceledException)
            {
                if (opCanceledException.CancellationToken == cts.Token)
                {
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
            }
        }

        protected void LogError(Exception ex)
        {
            Logger.LogError(ex);
        }

        protected void TrackEvent()
        {
        }

        #endregion
    }
}