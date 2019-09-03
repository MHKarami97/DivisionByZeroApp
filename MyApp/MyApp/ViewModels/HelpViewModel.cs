using System.Collections.Generic;
using Acr.UserDialogs;
using MyApp.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class HelpViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly ILocalizeService localizeService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;

        public HelpViewModel(IMvxNavigationService navigationService, IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.navigationService = navigationService;
            this.localizeService = localizeService;
            this.userDialogs = userDialogs;
            this.settings = settings;

            var infoItem = new List<HelpModel>();

            using (userDialogs.Loading("Loading"))
            {
                infoItem.Add(new HelpModel
                {
                    Name = "Cheese burger",
                    Description = "Hamburger accompanied with melted cheese. The term itself is a portmanteau of the words cheese and hamburger. The cheese is usually sliced, then added a short time before the hamburger finishes cooking to allow it to melt."
                });
                infoItem.Add(new HelpModel
                {
                    Name = "Veggie burger",
                    Description = "Veggie burger, garden burger, or tofu burger uses a meat analogue, a meat substitute such as tofu, textured vegetable protein, seitan (wheat gluten), Quorn, beans, grains or an assortment of vegetables, which are ground up and formed into patties."
                });
                infoItem.Add(new HelpModel
                {
                    Name = "Barbecue burger",
                    Description = "Prepared with ground beef, mixed with onions and barbecue sauce, and then grilled. Once the meat has been turned once, barbecue sauce is spread on top and grilled until the sauce caramelizes."
                });
                infoItem.Add(new HelpModel
                {
                    Name = "Chili burger",
                    Description = "Consists of a hamburger, with the patty topped with chili con carne."
                });
            }

            Info = infoItem;
        }

        public List<HelpModel> Info { get; set; }

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