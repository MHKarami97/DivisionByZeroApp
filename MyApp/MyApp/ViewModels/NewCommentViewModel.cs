using System;
using MvvmCross;
using MyApp.Helpers;
using Acr.UserDialogs;
using Entities;
using Entities.Return;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Rest.Api;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class NewCommentViewModel : MvxViewModel<object>
    {
        private readonly IUserDialogs _userDialogs;
        private readonly IMvxNavigationService _navigationService;
        private readonly Api<CommentReturnModel, CommentModel, int> _api;

        public NewCommentViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, Api<CommentReturnModel, CommentModel, int> api)
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
                TotalRate = 2.5;
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public object Id { get; set; }

        public string CommentText { get; set; }

        public double TotalRate { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand SendCommentCommand =>
            new MvxAsyncCommand(async () =>
            {
                try
                {
                    var result = await _api.Create(new CommentReturnModel()
                    {
                        Text = CommentText,
                        UserId = 0,
                        PostId = Convert.ToInt32(Id),
                        Star = TotalRate
                    });

                    if (result.IsSuccess)
                    {
                        await _navigationService.Navigate<CommentViewModel, object>(Id);
                    }
                    else
                    {
                        await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
                    }
                }
                catch (Exception)
                {
                    await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
                }
            });

        #endregion

        #region Toolbar

        #endregion
    }
}