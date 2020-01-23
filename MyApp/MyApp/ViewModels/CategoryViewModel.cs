using System;
using MvvmCross;
using Entities;
using Xamarin.Forms;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Syncfusion.XForms.Cards;
using System.Collections.Generic;
using MyApp.Rest.Api.Custom;

namespace MyApp.ViewModels
{
    public class CategoryViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly CategoryApi<CategoryModel> _api;

        public CategoryViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, CategoryApi<CategoryModel> api)
        {
            _userDialogs = userDialogs;
            _api = api;
            _navigationService = navigationService;
        }

        public override async void Start()
        {
            try
            {
                using (_userDialogs.Loading("Loading"))
                {
                    var result = await _api.GetAllMainCat();

                    Cats = result.Data;
                }
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public List<CategoryModel> Cats { get; set; }

        #endregion

        #region Events

        public MvxAsyncCommand<object> CategoryTapCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = Cats[index ?? 0];

                await _navigationService.Navigate<CategorySecondViewModel, object>(item.Id);
            });

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