using System;
using MvvmCross;
using MyApp.Models;
using MyApp.Helpers;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyApp.ViewModels
{
    public class NewComment : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public NewComment(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
            User = new UserModel
            {
                PhoneNumber = "9390709197",
                Name = "ali",
                LastName = "mohammadi",
                Email = "mhkarami1997@gmail.com",
                BirthDay = DateTime.Now.Date,
                NationalCode = 123445
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
                    await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));
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