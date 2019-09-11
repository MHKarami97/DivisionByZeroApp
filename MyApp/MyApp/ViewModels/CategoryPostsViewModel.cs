using System;
using MvvmCross;
using MyApp.Models;
using Xamarin.Forms;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Syncfusion.XForms.Cards;
using System.Collections.Generic;

namespace MyApp.ViewModels
{
    public class CategoryPostsViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public CategoryPostsViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
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
                    var posts = new List<PostShortModel>
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

                    Posts = posts;
                }
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public object Id { get; set; }

        public List<PostShortModel> Posts { get; set; }

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