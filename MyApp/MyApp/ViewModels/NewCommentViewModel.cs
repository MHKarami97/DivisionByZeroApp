using System;
using MvvmCross;
using MyApp.Helpers;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyApp.ViewModels
{
    public class NewCommentViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public NewCommentViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
        }

        #region Property

        public string CommentText { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand SendCommentCommand =>
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

        #endregion
    }
}