using System.Globalization;
using MyApp.Resources;
using MyApp.Services;
using MvvmCross;
using Plugin.SecureStorage;

namespace MyApp.Helpers
{
    public static class TranslateExtension
    {
        public static string Translate(this ILocalizeService localizeService, string str)
        {
            Resources.TranslateExtension._cultureInfo = CrossSecureStorage.Current.GetValue("lang") != null ? new CultureInfo(CrossSecureStorage.Current.GetValue("lang")) : Mvx.IoCProvider.Resolve<ILocalizeService>().GetCurrentCultureInfo();

            var lang = Resources.TranslateExtension._cultureInfo;

            var translation = AppResources.ResourceManager.GetString(str, lang);

            return string.IsNullOrEmpty(translation) ? str : translation;
        }
    }
}
