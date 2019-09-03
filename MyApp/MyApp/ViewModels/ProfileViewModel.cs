using System;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Helpers;
using MyApp.Models;

namespace MyApp.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IMvxLogProvider mvxLogProvider;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly IMvxLog log;

        public ProfileViewModel(IMvxNavigationService navigationService, IMvxLogProvider mvxLogProvider, Services.IAppSettings settings, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService;
            this.mvxLogProvider = mvxLogProvider;
            this.userDialogs = userDialogs;
            this.settings = settings;

            log = mvxLogProvider.GetLogFor(GetType());
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

        private UserModel _user;

        public UserModel User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        public IMvxAsyncCommand UpdateCommand =>
            new MvxAsyncCommand(async () =>
            {
                try
                {
                    await navigationService.Navigate<RootViewModel>();
                }
                catch (Exception e)
                {
                    await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));
                }
            });

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<RootViewModel>();
            });
    }
}