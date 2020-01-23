using System;
using MvvmCross;
using Xamarin.Forms;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Syncfusion.XForms.Cards;
using System.Collections.Generic;
using Entities;
using MyApp.Rest.Api.Custom;

namespace MyApp.ViewModels
{
    public class CategoryPostsViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private PostApi<PostModel> _api;

        public CategoryPostsViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, PostApi<PostModel> api)
        {
            _userDialogs = userDialogs;
            _api = api;
            _navigationService = navigationService;
        }

        public override void Prepare(object parameter)
        {
            Id = Convert.ToInt32(parameter);
        }

        public override async void Start()
        {
            try
            {
                using (_userDialogs.Loading("Loading"))
                {
                    var result = await _api.GetAllByCatId(Id);

                    Posts = result.Data;
                }
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public int Id { get; set; }

        public List<PostModel> Posts { get; set; }

        #endregion

        #region Events

        public MvxAsyncCommand<object> PostTapCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = Posts[index ?? 0];

                await _navigationService.Navigate<PostViewModel, object>(item.Id);
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