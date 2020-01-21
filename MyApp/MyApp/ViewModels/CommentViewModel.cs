using System;
using Entities;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using MvvmCross;
using MyApp.Helpers;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class CommentViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public CommentViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
            try
            {
                var comm = new List<CommentModel>();

                using (_userDialogs.Loading("Loading"))
                {

                    comm.Add(new CommentModel
                    {
                        Id = 1,
                        UserFullName = "Mohammad",
                        UserImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 2,
                        Star = 4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Text = "hello, this is my comment"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 2,
                        UserFullName = "Mohammad",
                        UserImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 2,
                        Star = 4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Text = "hello, this is my comment"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 3,
                        UserFullName = "Mohammad",
                        UserImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 2,
                        Star = 4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Text = "hello, this is my comment"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 4,
                        UserFullName = "Mohammad",
                        UserImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 2,
                        Star = 4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Text = "hello, this is my comment"
                    });
                }

                Comments = comm;

                TotalRate = 3.5;
                TotalRateText = TotalRate + " + 6k votes";
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }

        }

        #region Property

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
                await _navigationService.Navigate<NewCommentViewModel>();
            });

        #endregion
    }
}