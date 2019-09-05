using System;
using MvvmCross;
using MyApp.Models;
using Xamarin.Forms;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using XF.Material.Forms;
using MvvmCross.Commands;
using XF.Material.Forms.UI;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;


        public LoginViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _navigationService = navigationService;

            User = new UserModel();
        }

        #region Property

        public string MainPageButtonText { get; set; }

        public bool NotValidPhone { get; set; }

        public UserModel User { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand LoginCommand =>
           new MvxAsyncCommand(async () =>
           {
               try
               {
                   if (!string.IsNullOrEmpty(User.PhoneNumber) && User.PhoneNumber.Length == 11)
                   {
                        //var view = new SfTextInputLayout
                        //{
                        //    Hint = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("VerifyCode"),
                        //    CharMaxLength = 5
                        //};

                        var view = new MaterialTextField
                       {
                           HelperTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                           ErrorText = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidVerifyCode"),
                           Placeholder = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("VerifyCode"),
                           InputType = MaterialTextFieldInputType.Telephone,
                           IsMaxLengthCounterVisible = true,
                           MaxLength = 5
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
                           Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("YourPhoneNumber") + User.PhoneNumber,
                           null,
                           Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Verify"),
                            Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("ChangePhone"),
                            simpleDialogConfiguration);

                       if (result.Equals(true))
                       {
                            //var t = view.Text;

                            //var param = new Dictionary<string, WebSiteUser> { { "user", User } }; 

                            await _navigationService.Navigate<RootViewModel>();
                       }
                   }
                   else
                   {
                       NotValidPhone = true;
                       await MaterialDialog.Instance.SnackbarAsync(message: Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("NotValidPhone"));
                   }
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