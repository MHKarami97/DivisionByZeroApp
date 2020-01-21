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

namespace MyApp.ViewModels
{
    public class PostViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public PostViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
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
                    SinglePost = new PostModel
                    {
                        Id = 1,
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Title = "title of post",
                        ShortDescription = "short content of post",
                        Description = "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?"
                                      + "this is my post \n how are you? \n is this page good?",
                        Address = "post",
                        FullTitle = "bjbj",
                        CategoryName = "jnj",
                        UserFullName = "jnknk",
                        Date = "fdc",
                        Like = 1,
                        Visit = 1
                    };

                    var similars = new List<PostShortModel>
                     {
                        new PostShortModel
                        {
                            Id = 1,
                            Like = 2,
                            Visit = 3,
                            Title = "Post title",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        },
                        new PostShortModel
                        {
                            Id = 2,
                            Like = 5,
                            Visit = 6,
                            Title = "My post title",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        },
                        new PostShortModel
                        {
                            Id = 3,
                            Like = 2,
                            Visit = 3,
                            Title = "this is title of post",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        },
                        new PostShortModel
                        {
                            Id = 4,
                            Like = 2,
                            Visit = 3,
                            Title = "Post title",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        },
                        new PostShortModel
                        {
                            Id = 5,
                            Like = 2,
                            Visit = 3,
                            Title = "Post title",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        },
                        new PostShortModel
                        {
                            Id = 6,
                            Like = 2,
                            Visit = 3,
                            Title = "Post title",
                            Date = DateTime.Now.ToString("d"),
                            Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                        }
                };

                    SimilarPosts = similars;
                }
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Propery

        public PostModel SinglePost { get; set; }

        public List<PostShortModel> SimilarPosts { get; set; }

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