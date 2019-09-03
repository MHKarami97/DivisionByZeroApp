using System;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Helpers;
using MyApp.Services;
using System.Collections.Generic;
using MyApp.Models;
using MvvmCross;
using Xamarin.Forms;
using XF.Material.Forms;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class LoginViewModel : MvxViewModel<Dictionary<string, string>>
    {
        private readonly IMvxNavigationService navigationService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly ILocalizeService localizeService;

        private Dictionary<string, string> _parameter;

        public LoginViewModel(IMvxNavigationService navigationService, IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.navigationService = navigationService;
            this.settings = settings;
            this.userDialogs = userDialogs;
            this.localizeService = localizeService;

            User = new UserModel();

            Time = DateTime.Now.ToString("t");
        }

        public string MainPageButtonText { get; set; }

        //public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(async () =>
        //{
        //    var localizedText = localizeService.Translate("SecondPage_ByeBye_Localization");

        //    await userDialogs.AlertAsync(localizedText);
        //    await navigationService.Close(this);
        //});

        public override void Prepare(Dictionary<string, string> parameter)
        {
            _parameter = parameter;

            if (_parameter != null && _parameter.ContainsKey("ButtonText"))
                MainPageButtonText = "ButtonText";
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

        private bool _notValidPhone;
        public bool NotValidPhone
        {
            get
            {
                return _notValidPhone;
            }
            set
            {
                if (value == _notValidPhone)
                    return;

                _notValidPhone = value;
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

                            await navigationService.Navigate<RootViewModel>();
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
                    await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
                }
            });
    }
}