using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using Entities;
using MyApp.Rest.Api;
using MyApp.Rest.Api.Custom;

namespace MyApp.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly SearchApi<SearchModel, SearchModel, string> _api;

        public SearchViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _api = new SearchApi<SearchModel, SearchModel, string>("search");
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

            var result = await _api.Search(SearchText);
        }

        #region Property

        public List<string> SearchDataSource { get; set; }

        public string SearchText { get; set; }

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