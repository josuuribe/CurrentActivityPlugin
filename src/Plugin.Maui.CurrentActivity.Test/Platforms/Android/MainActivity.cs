using Android.App;
using Android.Widget;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;
using Plugin.CurrentActivity;

namespace Plugin.Maui.CurrentActivity.Test
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : MauiAppCompatActivity
    {
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			CrossCurrentActivity.Current.Init(this, bundle);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.MyButton);


			button.Click += delegate
			{
				StartActivity(typeof(SecondActivity));
			};
		}
	}
}