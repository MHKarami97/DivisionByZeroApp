using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using MyApp.Droid.Services;
using Serilog;

namespace MyApp.Droid
{
    public class Setup : MvxFormsAndroidSetup<MvxApp, MyApp.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<MyApp.Services.ILocalizeService>(() => new LocalizeService());
        }

        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        //.WriteTo.AndroidLog()
                        .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}