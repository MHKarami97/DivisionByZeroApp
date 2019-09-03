using System;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class PostViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly ILocalizeService localizeService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;

        public PostViewModel(IMvxNavigationService navigationService, IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.navigationService = navigationService;
            this.localizeService = localizeService;
            this.userDialogs = userDialogs;
            this.settings = settings;

            SinglePost = new Post
            {
                Id = 1,
                Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                Title = "title of post",
                CommentStatus = true,
                PostAuthor = "ali",
                Date = DateTime.Now.ToString("d"),
                ShortContent = "short content of post",
                Visit = 20,
                Tags = "new,blog,comment",
                Content = "this is my post \n how are you? \n is this page good?",
                CategoryId = 2,
                Address = "post",
                LanguageId = 1,
                Type = 1,
                Like = 20,
                Comment = 400
            };
        }

        public Post SinglePost { get; set; }

        public IMvxAsyncCommand ToolbarSearchCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<SearchViewModel>();
            });

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<RootViewModel>();
            });
    }
}