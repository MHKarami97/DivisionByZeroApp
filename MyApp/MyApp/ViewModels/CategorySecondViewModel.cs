using System;
using MvvmCross;
using MyApp.Models;
using MyApp.Helpers;
using MyApp.Services;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MyApp.ViewModels
{
    public class CategorySecondViewModel : MvxViewModel<object>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public CategorySecondViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
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
                var cats = new List<CategoryModel>();

                using (_userDialogs.Loading("Loading"))
                {
                    cats.Add(new CategoryModel
                    {
                        Id = 1,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 2,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 3,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 4,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 5,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 6,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 7,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 8,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 9,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 10,
                        Title = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                }

                Cats = cats;
            }
            catch (Exception e)
            {
                await _userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public object Id { get; set; }

        public List<CategoryModel> Cats { get; set; }

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