using MvvmCross;
using MvvmCross.Logging;
using MyApp.UWP.Services;
using MvvmCross.Forms.Platforms.Uap.Core;

namespace MyApp.UWP
{
    public class Setup : MvxFormsWindowsSetup<MvxApp, MyApp.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<MyApp.Services.ILocalizeService>(() => new LocalizeService());
        }

        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
           //var logPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Logs", "log-{Date}.txt");

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.Trace()
            //    .WriteTo.RollingFile(logPath)
            //    .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}