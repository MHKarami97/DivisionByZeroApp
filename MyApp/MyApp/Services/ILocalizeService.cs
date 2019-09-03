using System.Globalization;

namespace MyApp.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
