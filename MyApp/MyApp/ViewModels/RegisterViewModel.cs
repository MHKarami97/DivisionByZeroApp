using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XF.Material.Forms.UI.Dialogs;

namespace MyApp.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;


        public RegisterViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _navigationService = navigationService;

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
                       if(Security.EmailValid(User.Email))
                       {
                           if(Security.PasswordValid(User.Password))
                           {
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
               catch (Exception e)
               {
                   await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
               }
           });

        public IMvxAsyncCommand LoginCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   await _navigationService.Navigate<LoginViewModel>();
               }
               catch (Exception e)
               {
                   await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
               }
           });

        #endregion

        #region Toolbar



        #endregion
    }
}