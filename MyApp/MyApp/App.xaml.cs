using MvvmCross.Forms.Core;

namespace MyApp
{
    public partial class App : MvxFormsApplication
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUyMDBAMzEzNzJlMzIyZTMwTEV0K0JaZXY0ZUZZclhJd0t1ZkkvRS9mUXNvT2d6WGthRFE0OGx6WGRwcz0=");

            InitializeComponent();

            XF.Material.Forms.Material.Init(this, "Material.Configuration");
        }

        protected override void OnStart()
        {
            // Device Model (SMG-950U, iPhone10,6)
            // var device = DeviceInfo.Model;
            // 
            // // Manufacturer (Samsung)
            // var manufacturer = DeviceInfo.Manufacturer;
            // 
            // // Device Name (Motz's iPhone)
            // var deviceName = DeviceInfo.Name;
            // 
            // // Operating System Version Number (7.0)
            // var version = DeviceInfo.VersionString;
            // 
            // // Platform (Android)
            // var platform = DeviceInfo.Platform;
            // 
            // // Idiom (Phone)
            // var idiom = DeviceInfo.Idiom;
            // 
            // // Device Type (Physical)
            // var deviceType = DeviceInfo.DeviceType;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
