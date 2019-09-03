using System;
using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private readonly IMvxLogProvider mvxLogProvider;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly IMvxLog log;

        public MainViewModel(IMvxNavigationService navigationService, IMvxLogProvider mvxLogProvider, Services.IAppSettings settings, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService;
            this.mvxLogProvider = mvxLogProvider;
            this.settings = settings;
            this.userDialogs = userDialogs;

            log = mvxLogProvider.GetLogFor(GetType());

            CardTappedCommands = new Command<object>(CardTappedEvent);
            //CardTappedCommands = new Command<object>(CardTappedEvent); 
            //DeleteCommand = new Command<object>(async (model) => await DeleteExec(model));
        }

        private Dictionary<string, string> _parameter;

        public override void Prepare(Dictionary<string, string> parameter)
        {
            _parameter = parameter;
        }

        public override async void Start()
        {
            try
            {
                IsRefresh = false;

                var blogPost = new List<Post>();
                var cats = new List<CategoryModel>();

                using (userDialogs.Loading("Loading"))
                {
                    blogPost.Add(new Post
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

                    blogPost.Add(new Post
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

                    blogPost.Add(new Post
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

                    blogPost.Add(new Post
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

                    blogPost.Add(new Post
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
                }

                using (userDialogs.Loading("Loading"))
                {
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
                }

                BlogPosts = blogPost;
                Cats = cats;

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
                await userDialogs.AlertAsync(e.Message, Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Error"), Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Ok"));

                throw;
            }
        }

        private List<CarouselModel> imageCollection = new List<CarouselModel>();
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }

        private List<Post> _blogPosts;

        public List<Post> BlogPosts
        {
            get
            {
                return _blogPosts;
            }
            set
            {
                _blogPosts = value;
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

        private bool _isRefresh;

        public bool IsRefresh
        {
            get
            {
                return _isRefresh;
            }
            set
            {
                _isRefresh = value;
            }
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
                    Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("SelectLanguage"),
                    configuration: simpleDialogConfiguration,
                    confirmingText: Mvx.IoCProvider.Resolve<Services.ILocalizeService>().Translate("Confirm"),
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

        //public MvxAsyncCommand<Post> CardItemTappedCommand =>
        //    new MvxAsyncCommand<Post>(async (Id) =>
        //    {
        //        var z=Id;

        //        await MaterialDialog.Instance.SnackbarAsync(Id.ToString());
        //    });


        //public ICommand CardTappedCommands { get; set; }

        //private object cardDescription;

        //public object CardDescription
        //{
        //    get { return cardDescription; }
        //    set 
        //    {
        //        cardDescription = value;
        //    }
        //} 

        //private void CardTappedEvent(object args)
        //{
        //    if (args is SfCardLayout cardLayout)
        //        CardDescription = ((MainViewModel) cardLayout.BindingContext).BlogPosts[cardLayout.VisibleCardIndex]
        //            .Id;
        //    var z=cardDescription;
        //}  


        //public ICommand DeleteCommand { get; }

        //private async Task DeleteExec(object model)
        //{
        //    if (model is SfCardLayout cardLayout)
        //        CardDescription = ((MainViewModel) cardLayout.BindingContext).BlogPosts[cardLayout.VisibleCardIndex]
        //            .Id;
        //    var z=cardDescription;

        //    await MaterialDialog.Instance.SnackbarAsync(model.ToString());
        //}


        private ICommand cardTappedCommands;
        public ICommand CardTappedCommands { get; set; }
        private void CardTappedEvent(object args)
        {
            var fwsd=args as SfCardView;
            var cardLayout = args as SfCardLayout;
            var njk = (cardLayout.BindingContext as MainViewModel).BlogPosts[cardLayout.VisibleCardIndex].Id;
        }

        private IMvxAsyncCommand<string> _cardTappedCommand;

        public IMvxAsyncCommand<string> CardTappedCommand
        {
            get
            {
                _cardTappedCommand = _cardTappedCommand ?? new MvxAsyncCommand<string>(CardTapped);
                return _cardTappedCommand;
            }
        }

        private async Task CardTapped(string Id)
        {
            await navigationService.Navigate<PostViewModel>();
        }
    }
}