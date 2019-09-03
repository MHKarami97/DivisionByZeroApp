using System;
using MvvmCross;
using MyApp.Helpers;
using Xamarin.Forms;
using MyApp.Services;
using Acr.UserDialogs;
using Xamarin.Essentials;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyApp.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly ILocalizeService localizeService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;

        public AboutViewModel(IMvxNavigationService navigationService, IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.navigationService = navigationService;
            this.localizeService = localizeService;
            this.userDialogs = userDialogs;
            this.settings = settings;

            Version = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Version") + VersionTracking.CurrentVersion;
        }

        public string Version { get; set; }

        public IMvxAsyncCommand ToolbarSearchCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<SearchViewModel>();
            });

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<RootViewModel>();
            });

        public IMvxCommand CallByPhoneCommand =>
            new MvxCommand(() =>
           {
               Device.OpenUri(new Uri("tel://989390709197"));
           });

        public IMvxCommand CallByEmailCommand =>
            new MvxCommand(() =>
           {
               Device.OpenUri(new Uri("mailto:mhkarami1997@gmail.com"));
           });
    }
}