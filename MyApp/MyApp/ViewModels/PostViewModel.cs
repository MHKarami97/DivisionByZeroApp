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

namespace MyApp.ViewModels
{
    public class PostViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly PostApi<PostModel> _api;

        public PostViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, PostApi<PostModel> api)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _api = api;
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
                    var result = await _api.Get(Convert.ToInt32(Id));
                    var resultSimilar = await _api.GetSimilar(Convert.ToInt32(Id));

                    SinglePost = result.Data;

                    SimilarPosts = resultSimilar.Data;
                }
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Propery

        public PostModel SinglePost { get; set; }

        public List<PostModel> SimilarPosts { get; set; }

        public object Id { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand CommentClickCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<CommentViewModel>();
            });

        public IMvxAsyncCommand LikeClickCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<CommentViewModel>();
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