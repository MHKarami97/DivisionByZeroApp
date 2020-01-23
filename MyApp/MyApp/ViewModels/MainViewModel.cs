using System;
using MvvmCross;
using Entities;
using MyApp.Helpers;
using Xamarin.Forms;
using MyApp.Services;
using Acr.UserDialogs;
using XF.Material.Forms;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using Plugin.SecureStorage;
using XF.Material.Forms.UI;
using Syncfusion.XForms.Cards;
using System.Collections.Generic;
using MyApp.Rest.Api;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public MainViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override async void Start()
        {
            try
            {
                IsRefresh = false;

                var blogPost = new List<PostModel>();
                var cats = new List<CategoryModel>();
                var banners = new List<BannerModel>();

                using (_userDialogs.Loading("Loading"))
                {
                    blogPost.Add(new PostModel
                    {
                        Id = 1,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryName = "hjb",
                        ShortDescription = "short content",
                        UserFullName = "email@email.com",
                        Image = "logo.png",
                        Description = null,
                        Address = "address"
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 2,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryName = "hjb",
                        ShortDescription = "short content",
                        UserFullName = "email@email.com",
                        Image = "logo.png",
                        Description = null,
                        Address = "address"
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 3,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryName = "hjb",
                        ShortDescription = "short content",
                        UserFullName = "email@email.com",
                        Image = "logo.png",
                        Description = null,
                        Address = "address"
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 4,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryName = "hjb",
                        ShortDescription = "short content",
                        UserFullName = "email@email.com",
                        Image = "logo.png",
                        Description = null,
                        Address = "address"
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 5,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryName = "hjb",
                        ShortDescription = "short content",
                        UserFullName = "email@email.com",
                        Image = "logo.png",
                        Description = null,
                        Address = "address"
                    });

                    cats.Add(new CategoryModel
                    {
                        Id = 1,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 2,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 3,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 4,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 5,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 6,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 7,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 8,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 9,
                        Name = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 10,
                        Name = "my item"
                    });

                    banners.Add(new BannerModel
                    {
                        Id = 1,
                        Address = "https://itarfand.com",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Type = 1
                    });
                    banners.Add(new BannerModel
                    {
                        Id = 2,
                        Address = "https://itarfand.com",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Type = 1
                    });
                    banners.Add(new BannerModel
                    {
                        Id = 3,
                        Address = "https://itarfand.com",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Type = 1
                    });
                    banners.Add(new BannerModel
                    {
                        Id = 4,
                        Address = "https://itarfand.com",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Type = 1
                    });
                    banners.Add(new BannerModel
                    {
                        Id = 5,
                        Address = "https://itarfand.com",
                        Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg",
                        Type = 1
                    });
                }

                BlogPosts = blogPost;
                Banners = banners;
                Cats = cats;

                SingleImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg";

                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg")); ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));

                //await MaterialDialog.Instance.SnackbarAsync(message: Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("HelloMessage") + " " + Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("AppName"));
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Property

        public List<CarouselModel> ImageCollection { get; set; } = new List<CarouselModel>();

        public List<CategoryModel> Cats { get; set; }

        public List<BannerModel> Banners { get; set; }

        public List<PostModel> BlogPosts { get; set; }

        public bool IsRefresh { get; set; }

        public string SingleImage { get; set; }

        #endregion

        #region Events

        public MvxAsyncCommand<object> CardTappedCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = BlogPosts[index ?? 0];

                await _navigationService.Navigate<PostViewModel, object>(item.Id);
            });

        public MvxAsyncCommand<object> CatTappedCommand =>
            new MvxAsyncCommand<object>(async obj =>
            {
                var cardView = (obj as TappedEventArgs)?.Parameter as SfCardView;
                var cardLayout = cardView?.Parent as SfCardLayout;

                var index = cardLayout?.VisibleCardIndex;

                var item = Cats[index ?? 0];

                await _navigationService.Navigate<CategoryPostsViewModel, object>(item.Id);
            });

        //public IMvxAsyncCommand PullingEvent =>
        //    new MvxAsyncCommand(async () =>
        //    {
        //        IsRefresh = true;

        //        var blogPost = new List<Post>();

        //        System.Threading.Thread.Sleep(1000);

        //        blogPost.Add(new Post
        //        {
        //            Id = 1,
        //            Type = 1,
        //            Visit = 1,
        //            Title = "success refresh",
        //            Date = DateTime.Now,
        //            CategoryId = 1,
        //            ShortContent = "short content",
        //            PostAuthor = "email@email.com",
        //            Image = "logo.png",
        //            CommentStatus = true,
        //            Tags = "hello,tag",
        //            Content = null,
        //            Address = "address",
        //            LanguageId = 1
        //        });

        //        BlogPosts = blogPost;

        //        IsRefresh = false;
        //    });

        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarProfileCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<ProfileViewModel>();
            });

        public IMvxAsyncCommand ToolbarLangCommand =>
            new MvxAsyncCommand(async () =>
            {
                var view = new MaterialRadioButtonGroup
                {
                    Choices = new List<string>
                    {
                        "English",
                        "Persian"
                    },
                    TextColor = Material.GetResource<Color>(MaterialConstants.Color.BACKGROUND)
                };

                var simpleDialogConfiguration = new MaterialAlertDialogConfiguration
                {
                    BackgroundColor = Material.GetResource<Color>(MaterialConstants.Color.SECONDARY),
                    TitleTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                    MessageTextColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                    TintColor = Material.GetResource<Color>(MaterialConstants.Color.ON_SECONDARY),
                    CornerRadius = 8
                };

                await MaterialDialog.Instance.ShowCustomContentAsync(view,
                    Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("SelectLanguage"),
                    configuration: simpleDialogConfiguration,
                    confirmingText: Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Confirm"),
                    dismissiveText: null);

                switch (view.SelectedIndex)
                {
                    case 0:
                        CrossSecureStorage.Current.SetValue("lang", "en-US");
                        break;

                    case 1:
                        CrossSecureStorage.Current.SetValue("lang", "fa-IR");
                        break;
                }

                await MaterialDialog.Instance.SnackbarAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("LanguageChange"));
            });

        public IMvxAsyncCommand ToolbarSearchCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<SearchViewModel>();
            });

        #endregion
    }
}