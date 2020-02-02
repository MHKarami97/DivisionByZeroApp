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
using MyApp.Rest.Api.Custom;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace MyApp.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly PostApi<PostModel> _apiPost;
        private readonly Api<BannerModel> _apiBanner;
        private readonly CategoryApi<CategoryModel> _apiCategory;

        public MainViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
            _navigationService = navigationService;
            _apiPost = new PostApi<PostModel>("post");
            _apiBanner = new Api<BannerModel>("banner");
            _apiCategory = new CategoryApi<CategoryModel>("category");
        }

        public override async void Start()
        {
            try
            {
                IsRefresh = false;

                var resultPost = await _apiPost.GetCustom();
                var resultCat = await _apiCategory.GetAllMainCat();
                var resultBanner = await _apiBanner.GetAll();

                using (_userDialogs.Loading("Loading"))
                {
                    BlogPosts = resultPost.Data;
                    Banners = resultBanner.Data;
                    Cats = resultCat.Data;
                }

                SingleImage = "http://loremflickr.com/600/600/nature?filename=simple.jpg";

                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));
                // ImageCollection.Add(new CarouselModel("http://loremflickr.com/600/600/nature?filename=simple.jpg"));

                //await MaterialDialog.Instance.SnackbarAsync(message: Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("HelloMessage") + " " + Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("AppName"));
            }
            catch (Exception)
            {
                await _userDialogs.AlertAsync(Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Ok"));
            }
        }

        #region Property

        //public List<CarouselModel> ImageCollection { get; set; } = new List<CarouselModel>();

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
                if (CrossSecureStorage.Current.GetValue("token") != null)
                    await _navigationService.Navigate<ProfileViewModel>();

                await _navigationService.Navigate<LoginViewModel>();
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