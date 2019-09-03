using System;
using Xamarin.Forms;
using Acr.UserDialogs;
using MvvmCross.Logging;
using Xamarin.Essentials;
using System.Diagnostics;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.SecureStorage;
using MyApp.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MvvmCross;
using MyApp.Helpers;

namespace MyApp.ViewModels
{
    public class MasterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IMvxLogProvider mvxLogProvider;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly IMvxLog log;

        public MasterViewModel(IMvxNavigationService navigationService, IMvxLogProvider mvxLogProvider, Services.IAppSettings settings, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService;
            this.mvxLogProvider = mvxLogProvider;
            this.settings = settings;
            this.userDialogs = userDialogs;
        }

        public override async void Start()
        {
            try
            {
                if (CrossSecureStorage.Current.GetValue("userToken") == null)
                {
                    var menuItems = new MvxObservableCollection<MenuItemModel>
                    {
                        new MenuItemModel{Id = 1,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Login"), Icon = "avatarblack.png",Target = "Login"},
                        new MenuItemModel{Id = 2,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Category"), Icon = "backend.png",Target = "Category"},
                        new MenuItemModel{Id = 3,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("About"), Icon = "information.png",Target = "About"},
                        new MenuItemModel{Id = 4,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Help"), Icon = "help.png",Target = "Help"},
                        new MenuItemModel{Id = 5,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Share"), Icon = "share.png",Target = "Share"},
                        new MenuItemModel{Id = 6,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Exit"), Icon = "logout.png",Target = "Exit"}
                    };

                    MenuItemList = menuItems;
                }
                else
                {
                    var menuItems = new MvxObservableCollection<MenuItemModel>
                    {
                        new MenuItemModel{Id = 1,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Account"), Icon = "avatarblack.png",Target = "Profile"},
                        new MenuItemModel{Id = 2,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Category"), Icon = "backend.png",Target = "Category"},
                        new MenuItemModel{Id = 3,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("About"), Icon = "information.png",Target = "About"},
                        new MenuItemModel{Id = 4,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Help"), Icon = "help.png",Target = "Help"},
                        new MenuItemModel{Id = 5,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Share"), Icon = "share.png",Target = "Share"},
                        new MenuItemModel{Id = 6,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("LogOut"), Icon = "exit.png",Target = "LogOut"},
                        new MenuItemModel{Id = 7,Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Exit"), Icon = "logout.png",Target = "Exit"}
                    };

                    MenuItemList = menuItems;
                }

                Time = DateTime.Now.ToString("t");
            }
            catch (Exception e)
            {
                await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));
            }
        }

        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value == _time)
                    return;

                _time = value;
            }
        }

        public IMvxCommand MenuLogoCommand =>
            new MvxAsyncCommand(async () =>
            {
                await Browser.OpenAsync("http://itarfand.com", BrowserLaunchMode.SystemPreferred);
            });

        #region MenuItemList;

        private ObservableCollection<MenuItemModel> _menuItemList;

        public ObservableCollection<MenuItemModel> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }

        #endregion MenuItemList;

        #region ShowDetailPageAsyncCommand;

        private IMvxAsyncCommand<string> _showDetailPageAsyncCommand;

        public IMvxAsyncCommand<string> ShowDetailPageAsyncCommand
        {
            get
            {
                _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand<string>(ShowDetailPageAsync);
                return _showDetailPageAsyncCommand;
            }
        }

        private async Task ShowDetailPageAsync(string target)
        {
            switch (target)
            {
                case "Login":
                    if (CrossSecureStorage.Current.GetValue("userToken") == null)
                        await navigationService.Navigate<LoginViewModel>();
                    else
                        await navigationService.Navigate<ProfileViewModel>();
                    break;

                case "Profile":
                    if (CrossSecureStorage.Current.GetValue("userToken") == null)
                        await navigationService.Navigate<LoginViewModel>();
                    else
                        await navigationService.Navigate<ProfileViewModel>();
                    break;

                case "Category":
                    await navigationService.Navigate<CategoryViewModel>();
                    break;

                case "About":
                    await navigationService.Navigate<AboutViewModel>();
                    break;

                case "Help":
                    await navigationService.Navigate<HelpViewModel>();
                    break;

                case "Share":
                    await Share.RequestAsync(new ShareTextRequest
                    {
                        Text = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("ShareText"),
                        Title = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("AppName")
                    });
                    break;

                case "LogOut":
                    Process.GetCurrentProcess().CloseMainWindow();
                    Process.GetCurrentProcess().Close();
                    break;

                case "Exit":
                    Process.GetCurrentProcess().CloseMainWindow();
                    Process.GetCurrentProcess().Close();
                    break;
            }

            switch (Application.Current.MainPage)
            {
                case MasterDetailPage masterDetailPage:
                    masterDetailPage.IsPresented = false;
                    break;

                case NavigationPage navigationPage when navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail:
                    nestedMasterDetail.IsPresented = false;
                    break;
            }
        }

        #endregion ShowDetailPageAsyncCommand;
    }
}