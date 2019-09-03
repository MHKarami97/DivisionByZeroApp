using System.Globalization;

namespace MyApp.UWP.Services
{
    public class LocalizeService : MyApp.Services.ILocalizeService
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }
    }
}