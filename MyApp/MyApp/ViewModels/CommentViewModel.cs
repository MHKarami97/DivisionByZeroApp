using System;
using MyApp.Models;
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
                        Author = "Mohammad",
                        AuthorImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 2,
                        Star = 4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Comment = "hello, this is my comment"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 2,
                        Author = "Ali",
                        AuthorImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 6,
                        Star = 5,
                        Time = DateTime.Now.ToString("MMMM"),
                        Comment = "the best post in the world"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 3,
                        Author = "Hossein",
                        AuthorImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 22,
                        Star = 4.4,
                        Time = DateTime.Now.ToString("MMMM"),
                        Comment = "very good post about what we do in the weekend"
                    });

                    comm.Add(new CommentModel
                    {
                        Id = 4,
                        Author = "Maraym",
                        AuthorImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Like = 8,
                        Star = 2.5,
                        Time = DateTime.Now.ToString("MMMM"),
                        Comment = "Thank you about this post"
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