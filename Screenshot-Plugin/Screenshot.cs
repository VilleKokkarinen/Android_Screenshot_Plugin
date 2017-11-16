﻿/// <summary>
/// Open Source Screenshot Plugin for Android devices
/// 
/// 
/// Ville Kokkarinen | @ | kokkarinen.ville@gmail.com
/// 
/// </summary>

using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(Screenshot_Plugin.SnapshotService))]
namespace Screenshot_Plugin
{

    //surprise
    /// <summary>
    /// Initializes a new instance of the <see cref="Screenshot"/> class.
    /// </summary>
    public class SnapshotService : ISnapShotService
    {
        public void TakeScreenShot()
        {
            var screenshotPath =
            Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
            Java.IO.File.Separator +
            "screenshot.png";

            var rootView = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView;
            
            using (var screenshot = Android.Graphics.Bitmap.CreateBitmap(
                    rootView.Width,
                    rootView.Height,
                    Android.Graphics.Bitmap.Config.Argb8888))
            {
                var canvas = new Android.Graphics.Canvas(screenshot);
                rootView.Draw(canvas);

                using (var screenshotOutputStream = new System.IO.FileStream(
                            screenshotPath,
                            System.IO.FileMode.Create))
                {
                    screenshot.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 90, screenshotOutputStream);
                    screenshotOutputStream.Flush();
                    screenshotOutputStream.Close();
                }
            }
        }
    }
}