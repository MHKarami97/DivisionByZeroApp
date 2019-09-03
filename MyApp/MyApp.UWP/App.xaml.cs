using System.Reflection;
using Microsoft.AppCenter;
using FFImageLoading.Forms;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using MvvmCross.Forms.Platforms.Uap.Views;
using Windows.ApplicationModel.Activation;

namespace MyApp.UWP
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class UwpApp : MvxWindowsApplication<Setup, MvxApp, MyApp.App, MainPage>
    {
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            var config = new FFImageLoading.Config.Configuration
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
            };
            FFImageLoading.ImageService.Instance.Initialize(config);

            var assembliesToInclude = new List<Assembly>
            {
                typeof(CachedImage).GetTypeInfo().Assembly,
                typeof(FFImageLoading.Forms.Platform.CachedImageRenderer).GetTypeInfo().Assembly
            };

            Xamarin.Forms.Forms.Init(e, assembliesToInclude);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            AppCenter.Start("87840556-1cbe-42e9-9091-68200e5c5adc", typeof(Analytics));

            base.OnLaunched(e);
        }
    }
}