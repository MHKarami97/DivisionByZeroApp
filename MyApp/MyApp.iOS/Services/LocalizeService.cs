using System;
using Foundation;
using System.Globalization;

namespace MyApp.iOS.Services
{
    public class LocalizeService : MyApp.Services.ILocalizeService
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLanguageOnly = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLanguageOnly = pref.Substring(0, 2);
                if (prefLanguageOnly == "fa")
                {
                    if (pref == "fa")
                        pref = "fa-IR";
                    else
                        pref = "fa-IR"; // Portugal
                }
                netLanguage = pref.Replace("_", "-");
                Console.WriteLine("preferred language:" + netLanguage);
            }
            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                ci = new CultureInfo(prefLanguageOnly);
            }
            return ci;
        }
    }
}
