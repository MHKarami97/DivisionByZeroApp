using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using MyApp.Rest.Api.Custom;
using Syncfusion.XForms.Cards;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class CategorySecondViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly CategoryApi<CategoryModel> _api;

        public CategorySecondViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, CategoryApi<CategoryModel> api)
        {
            _api = api;
            _userDialogs = userDialogs;
            _navigationService = navigationService;
        }

        public override void Prepare(object parameter)
        {
            Id = parameter;
        }

        public override async void Start()
        {
            try
            {
                using (_userDialogs.Loading("Loading"))
                {
                    var result = await _api.GetAllByCatId(Convert.ToInt32(Id));

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

        public object Id { get; set; }

        public List<CategoryModel> Cats { get; set; }

        #endregion

        #region Events

        public MvxAsyncCommand<object> CatTapCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = Cats[index ?? 0];

                await _navigationService.Navigate<CategoryPostsViewModel, object>(item.Id);
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