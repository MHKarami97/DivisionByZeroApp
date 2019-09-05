﻿using System;
using MyApp.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class PostViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;

        public PostViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(object parameter)
        {
            Id = (int)parameter;
        }

        public override async Task Initialize()
        {
            var id = Id;

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

        #region Propery

        public Post SinglePost { get; set; }

        public int Id { get; set; }

        #endregion

        #region Events

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