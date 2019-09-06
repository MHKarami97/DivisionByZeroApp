using MyApp.Models;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MyApp.ViewModels
{
    public class CommentViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public CommentViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
        }

        #region Property

        public List<CommentModel> Comments { get; set; }

        #endregion

        #region Events

        

        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarNewCommentCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RootViewModel>();
            });

        #endregion
    }
}