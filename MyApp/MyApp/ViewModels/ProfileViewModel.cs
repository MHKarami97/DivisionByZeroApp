using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Rest.Api.Custom;
using MyApp.Services;
using Plugin.SecureStorage;

namespace MyApp.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly UserApi<UserModel, UserModel, int> _api;

        public ProfileViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _api = new UserApi<UserModel, UserModel, int>("user");
        }

        public override async void Start()
        {
            try
            {
                var userId = CrossSecureStorage.Current.GetValue("userId");

                if (string.IsNullOrEmpty(userId))
                    await _navigationService.Navigate<LoginViewModel>();


                using (_userDialogs.Loading("Loading"))
                {
                    var result = await _api.Get(Convert.ToInt32(userId));

                    User = result.Data;
                }
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
            }
        }

        #region Property

        public UserModel User { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand UpdateCommand =>
            new MvxAsyncCommand(async () =>
            {
                try
                {
                    await _navigationService.Navigate<RootViewModel>();
                }
                catch (Exception)
                {
                    await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
                }
            });

        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RootViewModel>();
            });

        #endregion
    }
}