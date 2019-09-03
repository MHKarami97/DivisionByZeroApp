using System;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Helpers;
using MyApp.Services;
using System.Collections.Generic;
using MyApp.Models;
using MvvmCross;

namespace MyApp.ViewModels
{
    public class CategoryViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly ILocalizeService localizeService;

        public CategoryViewModel(IMvxNavigationService navigationService, IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.settings = settings;
            this.userDialogs = userDialogs;
            this.localizeService = localizeService;
            this.navigationService = navigationService;
        }

        public override async void Start()
        {
            try
            {
                var cats = new List<CategoryModel>();

                using (userDialogs.Loading("Loading"))
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
                await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        private List<CategoryModel> _cats;

        public List<CategoryModel> Cats
        {
            get
            {
                return _cats;
            }
            set
            {
                _cats = value;
            }
        }

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