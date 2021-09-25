using Android.App;
using Android.Runtime;
using Android.Widget;
using Microsoft.Maui;
using Plugin.CurrentActivity;
using System;

namespace Plugin.Maui.CurrentActivity.Test
{
    [Application]
    public class MainApplication : MauiApplication
    {
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			CrossCurrentActivity.Current.Init(this);
			CrossCurrentActivity.Current.ActivityStateChanged += Current_ActivityStateChanged;

			CrossCurrentActivity.Current.WaitForActivityAsync().ContinueWith(x =>
			{
				Console.WriteLine("This returned");
			});
		}

		private void Current_ActivityStateChanged(object sender, ActivityEventArgs e)
		{
			Toast.MakeText(Android.App.Application.Context, $"Activity Changed: {e.Activity.LocalClassName} -  {e.Event}", ToastLength.Short).Show();
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}