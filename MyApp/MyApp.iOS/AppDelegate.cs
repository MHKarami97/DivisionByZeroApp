using BaHamBekhanim.Core;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace MyApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, MvxApp, FormsApp>
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.MakeKeyAndVisible();

#if ENABLE_TEST_CLOUD
            // requires Xamarin Test Cloud Agent
            Xamarin.Calabash.Start();
#endif

            AppCenter.Start("18907712-7d48-4515-b71b-f753f9e49de2",
                typeof(Analytics), typeof(Crashes));

            XF.Material.iOS.Material.Init();

            return base.FinishedLaunching(app, options);
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.

            base.OnResignActivation(application);
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.

            base.DidEnterBackground(application);
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.

            base.WillEnterForeground(application);
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.

            base.OnActivated(application);
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.

            base.WillTerminate(application);
        }
    }
}


