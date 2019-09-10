using System;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross;
using Plugin.SecureStorage;
using MyApp.Helpers;
using MyApp.Services;
using Syncfusion.XForms.Cards;
using Xamarin.Forms;
using XF.Material.Forms;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class MainViewModel : MvxViewModel<Dictionary<string, string>>
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IUserDialogs userDialogs;

        public MainViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService;
            this.userDialogs = userDialogs;
        }

        public override void Prepare(Dictionary<string, string> parameter)
        {
        }

        public override async void Start()
        {
            try
            {
                IsRefresh = false;

                var blogPost = new List<PostModel>();
                var cats = new List<CategoryModel>();
                var banners = new List<BannerModel>();

                using (userDialogs.Loading("Loading"))
                {
                    blogPost.Add(new PostModel
                    {
                        Id = 1,
                        Type = 1,
                        Visit = 1,
                        Title = "this is my blog title in site how you",
                        Date = DateTime.Now.ToString("d"),
                        CategoryId = 1,
                        ShortContent = "short content",
                        PostAuthor = "email@email.com",
                        Image = "logo.png",
                        CommentStatus = true,
                        Tags = "hello,tag",
                        Content = null,
                        Address = "address",
                        LanguageId = 1
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 2,
                        Type = 1,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryId = 1,
                        ShortContent = "short content",
                        PostAuthor = "email@email.com",
                        Image = "logo.png",
                        CommentStatus = true,
                        Tags = "hello,tag",
                        Content = null,
                        Address = "address",
                        LanguageId = 1
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 3,
                        Type = 1,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryId = 1,
                        ShortContent = "short content",
                        PostAuthor = "email@email.com",
                        Image = "logo.png",
                        CommentStatus = true,
                        Tags = "hello,tag",
                        Content = null,
                        Address = "address",
                        LanguageId = 1
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 4,
                        Type = 1,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryId = 1,
                        ShortContent = "short content",
                        PostAuthor = "email@email.com",
                        Image = "logo.png",
                        CommentStatus = true,
                        Tags = "hello,tag",
                        Content = null,
                        Address = "address",
                        LanguageId = 1
                    });
                    blogPost.Add(new PostModel
                    {
                        Id = 5,
                        Type = 1,
                        Visit = 1,
                        Title = "my blog title",
                        Date = DateTime.Now.ToString("d"),
                        CategoryId = 1,
                        ShortContent = "short content",
                        PostAuthor = "email@email.com",
                        Image = "logo.png",
                        CommentStatus = true,
                        Tags = "hello,tag",
                        Content = null,
                        Address = "address",
                        LanguageId = 1
                    });

                    cats.Add(new CategoryModel
                    {
                        Id = 1,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 2,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 3,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 4,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 5,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 6,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 7,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 8,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 9,
                        Title = "my item"
                    });
                    cats.Add(new CategoryModel
                    {
                        Id = 10,
                        Title = "my item"
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
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));

                //await MaterialDialog.Instance.SnackbarAsync(message: Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("HelloMessage") + " " + Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("AppName"));
            }
            catch (Exception e)
            {
                await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        #region Events

        private async Task CardTapped(object args)
        {
            var cardView = (args as TappedEventArgs)?.Parameter as SfCardView;
            var cardLayout = cardView?.Parent as SfCardLayout;

            var index = cardLayout?.VisibleCardIndex;

            var item = BlogPosts[index ?? 0];

            await navigationService.Navigate<PostViewModel, object>(item.Id);
        }

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

        #region Property

        public List<CarouselModel> ImageCollection { get; set; } = new List<CarouselModel>();

        private IMvxAsyncCommand<object> _cardTappedCommand;

        public IMvxAsyncCommand<object> CardTappedCommand
        {
            get
            {
                _cardTappedCommand = _cardTappedCommand ?? new MvxAsyncCommand<object>(CardTapped);
                return _cardTappedCommand;
            }
        }

        public List<CategoryModel> Cats { get; set; }

        public List<BannerModel> Banners { get; set; }

        public List<PostModel> BlogPosts { get; set; }

        public bool IsRefresh { get; set; }

        public string SingleImage { get; set; }

        #endregion

        #region Toolbar

        public IMvxAsyncCommand ToolbarProfileCommand =>
            new MvxAsyncCommand(async () =>
            {
                await navigationService.Navigate<ProfileViewModel>();
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
                await navigationService.Navigate<SearchViewModel>();
            });

        #endregion
    }
}