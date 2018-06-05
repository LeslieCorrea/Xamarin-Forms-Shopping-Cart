using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using FFImageLoading.Forms.Platform;

namespace ShoppingCarts.Droid
{
    [Activity(Label = "ShoppingCarts", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // Changing to App's theme since we are OnCreate and we are ready to
            // "hide" the splash
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            base.SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            CachedImageRenderer.Init(enableFastRenderer: true);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}