using System;
using Entities;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using MvvmCross;
using MyApp.Helpers;
using MyApp.Rest.Api.Custom;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class CommentViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly CommentApi<CommentModel> _api;

        public CommentViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, CommentApi<CommentModel> api)
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
                    var result = await _api.GetAllByPostId(Convert.ToInt32(Id));

                    Comments = result.Data;
                }

                TotalRate = 3.5;
                TotalRateText = TotalRate + " + 6k votes";
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public object Id { get; set; }

        public List<CommentModel> Comments { get; set; }

        public double TotalRate { get; set; }

        public string TotalRateText { get; set; }

        #endregion

        #region Events


        #endregion

        #region Toolbar


        public IMvxAsyncCommand ToolbarNewCommentCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<NewCommentViewModel, object>(Id);
            });

        #endregion
    }
}