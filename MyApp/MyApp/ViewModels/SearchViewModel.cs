using System.Collections.Generic;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyApp.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IMvxLogProvider mvxLogProvider;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly IMvxLog log;

        public SearchViewModel(IMvxNavigationService navigationService, IMvxLogProvider mvxLogProvider, Services.IAppSettings settings, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService;
            this.mvxLogProvider = mvxLogProvider;
            this.userDialogs = userDialogs;
            this.settings = settings;

            log = mvxLogProvider.GetLogFor(GetType());
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
        }

        private List<string> _searchDataSource;

        public List<string> SearchDataSource
        {
            get
            {
                return _searchDataSource;
            }
            set
            {
                _searchDataSource = value;
            }
        }

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<RootViewModel>();
            });
    }
}