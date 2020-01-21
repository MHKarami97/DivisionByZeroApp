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
using Syncfusion.XForms.Cards;
using Xamarin.Forms;

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
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 2,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 3,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 4,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 5,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 6,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 7,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 8,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 9,
                        Name = "my item",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 10,
                        Name = "my item",
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

        public MvxAsyncCommand<object> CatTapCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = Cats[index ?? 0];

                await _navigationService.Navigate<CategoryPostsViewModel, object>(item.Id);
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