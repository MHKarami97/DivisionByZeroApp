﻿using System;
using MvvmCross;
using Entities;
using Xamarin.Forms;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using XF.Material.Forms;
using MvvmCross.Commands;
using XF.Material.Forms.UI;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Rest.Api.Custom;
using Plugin.SecureStorage;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly UserApi<UserModel, UserModel, int> _api;

        public LoginViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _navigationService = navigationService;
            _api = new UserApi<UserModel, UserModel, int>("user");

            User = new UserModel();
        }

        public override async void Start()
        {
            if (CrossSecureStorage.Current.GetValue("token") != null)
            {
                await _navigationService.Navigate<ProfileViewModel>();
            }
        }

        #region Property

        public string MainPageButtonText { get; set; }

        public bool NotValid { get; set; }

        public UserModel User { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand LoginCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   if (!string.IsNullOrEmpty(User.Email) && Security.EmailValid(User.Email))
                   {
                       var view = new MaterialTextField
                       {
                           HelperTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                           ErrorText = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidPassword"),
                           Placeholder = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Password"),
                           InputType = MaterialTextFieldInputType.Password,
                           IsMaxLengthCounterVisible = true
                       };

                       var simpleDialogConfiguration = new MaterialAlertDialogConfiguration
                       {
                           BackgroundColor = Material.GetResource<Color>(MaterialConstants.Color.SECONDARY),
                           TitleTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                           MessageTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                           TintColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                           MessageFontFamily = Material.GetResource<OnPlatform<string>>("FontFamily.TeshrinRegular"),
                           TitleFontFamily = Material.GetResource<OnPlatform<string>>("FontFamily.TeshrinRegular"),
                           CornerRadius = 8
                       };

                       var result = await MaterialDialog.Instance.ShowCustomContentAsync(view,
                           null,
                           null,
                           Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Verify"),
                            Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Edit"),
                            simpleDialogConfiguration);

                       if (result.Equals(true))
                       {
                           //var t = view.Text;

                           //var param = new Dictionary<string, WebSiteUser> { { "user", User } }; 

                           var apiResult = await _api.Token(User.Email, User.Password);

                           if (apiResult.IsSuccess)
                           {
                               CrossSecureStorage.Current.SetValue("token", apiResult.Data.Access_token);

                               await _navigationService.Navigate<RootViewModel>();
                           }

                           await _navigationService.Navigate<LoginViewModel>();
                       }
                   }
                   else
                   {
                       NotValid = true;
                       await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidEmail"));
                   }
               }
               catch (Exception)
               {
                   await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
               }
           });

        public IMvxAsyncCommand SignupCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   await _navigationService.Navigate<RegisterViewModel>();
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