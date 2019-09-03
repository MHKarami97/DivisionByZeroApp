using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MyApp.Droid
{
    [Activity(
        Label = "Chi kayro"
        , MainLauncher = true
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ConfigurationChanges = ConfigChanges.ScreenSize
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : MvxFormsSplashScreenAppCompatActivity<Setup, MvxApp, App>
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.HideNavigation;

            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            Forms.ViewInitialized += (sender, e) =>
            {
                if (e != null && !string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            base.OnCreate(bundle);
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            AppCenter.Start(
                "60a0a275-523a-4433-9ed1-39739f3b13c2",
                typeof(Analytics),
                typeof(Crashes));

            StartActivity(typeof(FormsApplicationActivity));
            return Task.CompletedTask;
        }
    }
}