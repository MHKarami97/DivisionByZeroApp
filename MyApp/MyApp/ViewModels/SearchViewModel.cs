using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using MyApp.Rest.Api;
using MyApp.Rest.Entities.Post;

namespace MyApp.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public SearchViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
            SearchDataSource = new List<string>
            {
                "text",
                "search",
                "about",
                "help",
                "app"
            };

            var result = await new Api<Post, Post, int>("post").GetAll();

            var t = result;
        }

        #region Property

        public List<string> SearchDataSource { get; set; }

        #endregion

        #region Events



        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RootViewModel>();
            });

        #endregion
    }
}