using System.Globalization;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;
using Plugin.SecureStorage;

namespace MyApp
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<Services.IAppSettings, Services.AppSettings>();
            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            Resources.AppResources.Culture = CrossSecureStorage.Current.GetValue("lang") != null ? new CultureInfo(CrossSecureStorage.Current.GetValue("lang")) : Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<ViewModels.RootViewModel>();
        }
    }
}