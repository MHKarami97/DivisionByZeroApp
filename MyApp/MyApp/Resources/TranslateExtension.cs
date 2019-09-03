using MvvmCross;
using System;
using System.Globalization;
using Plugin.SecureStorage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Resources
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public static CultureInfo _cultureInfo { get; set; }

        public TranslateExtension()
        {
            _cultureInfo = CrossSecureStorage.Current.GetValue("lang") != null ? new CultureInfo(CrossSecureStorage.Current.GetValue("lang")) : Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            var translation = AppResources.ResourceManager.GetString(Text, _cultureInfo);

#if DEBUG
            if (translation == null)
            {
                throw new ArgumentException(string.Format("Key {0} was not found for culture {1}.", Text, _cultureInfo));
            }
#endif
            return translation;
        }
    }
}