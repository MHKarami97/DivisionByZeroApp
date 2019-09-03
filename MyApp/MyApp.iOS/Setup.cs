using MvvmCross;
using MvvmCross.Logging;
using MyApp.iOS.Services;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace MyApp.iOS
{
    public class Setup : MvxFormsIosSetup<MvxApp, App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<MyApp.Services.ILocalizeService>(() => new LocalizeService());
        }

        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
            //Log.Logger = new LoggerConfiguration()
            //            .MinimumLevel.Debug()
            //            .WriteTo.NSLog()
            //            .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}