using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Rest.Api.Custom;
using Plugin.SecureStorage;
using XF.Material.Forms.UI.Dialogs;

namespace MyApp.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly UserApi<UserModel, UserModel, int> _api;

        public RegisterViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _navigationService = navigationService;
            _api = new UserApi<UserModel, UserModel, int>("user");

            User = new UserModel();
        }

        #region Property

        public string MainPageButtonText { get; set; }

        public bool NotValid { get; set; }

        public UserModel User { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand SignupCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   if (!string.IsNullOrEmpty(User.Email) && !string.IsNullOrEmpty(User.Password) &&
                       !string.IsNullOrEmpty(User.ConfirmPassword) && User.Password.Equals(User.ConfirmPassword))
                   {
                       if (Security.EmailValid(User.Email))
                       {
                           if (Security.PasswordValid(User.Password))
                           {
                               var result = await _api.Create(User);

                               if (result.IsSuccess)
                               {
                                   CrossSecureStorage.Current.SetValue("token", result.Data.Access_token);

                                   await _navigationService.Navigate<RootViewModel>();
                               }

                               await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"));

                               await _navigationService.Navigate<RootViewModel>();
                           }
                           else
                           {
                               NotValid = true;

                               await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidRegisterPassword"));
                           }
                       }
                       else
                       {
                           NotValid = true;

                           await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidEmail"));
                       }
                   }
                   else
                   {
                       NotValid = true;

                       await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidData"));
                   }
               }
               catch (Exception)
               {
                   await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
               }
           });

        public IMvxAsyncCommand LoginCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   await _navigationService.Navigate<LoginViewModel>();
               }
               catch (Exception)
               {
                   await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
               }
           });

        #endregion

        #region Toolbar



        #endregion
    }
}