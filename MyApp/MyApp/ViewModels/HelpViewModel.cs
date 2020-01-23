using Entities;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using MyApp.Rest.Api;

namespace MyApp.ViewModels
{
    public class HelpViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly Api<HelpModel> _api;

        public HelpViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _api = new Api<HelpModel>("help");
            _navigationService = navigationService;
        }

        public override async void Start()
        {
            using (_userDialogs.Loading("Loading"))
            {
                var result = await _api.GetAll();

                Info = result.Data;
            }
        }

        #region Property

        public List<HelpModel> Info { get; set; }

        #endregion

        #region Events



        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarSearchCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<SearchViewModel>();
            });

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RootViewModel>();
            });

        #endregion
    }
}