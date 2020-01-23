using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public ProfileViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
            User = new UserModel
            {
                PhoneNumber = "9390709197",
                FullName = "ali",
                Email = "mhkarami1997@gmail.com",
                Birthday = DateTime.Now.Date,
                Gender = GenderType.Male,
                UserName = "mhkarami1997"
            };
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
                catch (Exception e)
                {
                    await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));
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