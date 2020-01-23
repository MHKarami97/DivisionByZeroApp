using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Base;
using Acr.UserDialogs;
using MvvmCross.ViewModels;
using Plugin.SecureStorage;
using System.Globalization;
using MvvmCross.Plugin.Json;
using MyApp.Rest.Api;
using MyApp.Rest.Interfaces;
using MyApp.Rest.Repositories;

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

            Mvx.IoCProvider.RegisterType(typeof(IRepository<,,>), typeof(Repository<,,>));
            Mvx.IoCProvider.RegisterType<Services.IAppSettings, Services.AppSettings>();
            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);

            Resources.AppResources.Culture = CrossSecureStorage.Current.GetValue("lang") != null ? new CultureInfo(CrossSecureStorage.Current.GetValue("lang")) : Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<ViewModels.RootViewModel>();
        }
    }
}