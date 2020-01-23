using System;
using MvvmCross;
using Entities;
using Xamarin.Forms;
using MyApp.Helpers;
using Acr.UserDialogs;
using Xamarin.Essentials;
using System.Diagnostics;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.SecureStorage;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MyApp.Services;


namespace MyApp.ViewModels
{
    public class MasterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public MasterViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
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
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));
            }
        }

        #region Toolbar

        public IMvxCommand MenuLogoCommand =>
            new MvxAsyncCommand(async () =>
            {
                await Browser.OpenAsync("http://itarfand.com", BrowserLaunchMode.SystemPreferred);
            });

        #endregion



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
                        await _navigationService.Navigate<LoginViewModel>();
                    else
                        await _navigationService.Navigate<ProfileViewModel>();
                    break;

                case "Profile":
                    if (CrossSecureStorage.Current.GetValue("userToken") == null)
                        await _navigationService.Navigate<LoginViewModel>();
                    else
                        await _navigationService.Navigate<ProfileViewModel>();
                    break;

                case "Category":
                    await _navigationService.Navigate<CategoryViewModel>();
                    break;

                case "About":
                    await _navigationService.Navigate<AboutViewModel>();
                    break;

                case "Help":
                    await _navigationService.Navigate<HelpViewModel>();
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