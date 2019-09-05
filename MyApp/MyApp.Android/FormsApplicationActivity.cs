using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using FFImageLoading;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MyApp.Droid
{
    [Activity(Label = "FormsApplicationActivity",
              ScreenOrientation = ScreenOrientation.Portrait,
              LaunchMode = LaunchMode.SingleTask)]
    public class FormsApplicationActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.Toolbar;
            TabLayoutResource = Resource.Layout.Tabbar;

            //Window.AddFlags(WindowManagerFlags.Fullscreen);

            //SetContentView(Resource.Layout.Tabbar);

            //var uiOptions = (int)Window.DecorView.SystemUiVisibility;

            //uiOptions |= (int)SystemUiFlags.LowProfile;
            //uiOptions |= (int)SystemUiFlags.HideNavigation;
            //uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            //uiOptions |= (int)SystemUiFlags.Fullscreen;

            //Window.DecorView.SystemUiVisibility =
            //    (StatusBarVisibility)uiOptions;
            
            //if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            //{
            //    Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            //    Window.AddFlags(WindowManagerFlags.LayoutInScreen);
            //    Window.DecorView.SetFitsSystemWindows(true);

            //    Window.DecorView.SystemUiVisibility = 0;
            //    var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //    if (statusBarHeightInfo != null) statusBarHeightInfo.SetValue(this, 0);
            //    Window.SetStatusBarColor(new Android.Graphics.Color(18, 52, 86, 255));
            //}

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUyMDBAMzEzNzJlMzIyZTMwTEV0K0JaZXY0ZUZZclhJd0t1ZkkvRS9mUXNvT2d6WGthRFE0OGx6WGRwcz0=");

            AppCenter.Start("60a0a275-523a-4433-9ed1-39739f3b13c2",
                typeof(Analytics), typeof(Crashes));

            base.OnCreate(bundle);

            //Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.HideNavigation;

            CachedImageRenderer.Init(true);
            var ignore = typeof(SvgCachedImage);

            var config = new FFImageLoading.Config.Configuration
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false
            };
            ImageService.Instance.Initialize(config);

            UserDialogs.Init(this);

            XF.Material.Droid.Material.Init(this, bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);

            EntryCustomReturn.Forms.Plugin.Android.CustomReturnEntryRenderer.Init();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}