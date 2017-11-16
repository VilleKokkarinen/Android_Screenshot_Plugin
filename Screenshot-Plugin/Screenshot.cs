/// <summary>
/// Open Source Screenshot Plugin for Android devices
/// 
/// 
/// Ville Kokkarinen | @ | kokkarinen.ville@gmail.com
/// 
/// </summary>

using Android.App;
using Android.Views;
using Android.Graphics;

[assembly: Xamarin.Forms.Dependency(typeof(Screenshot_Plugin.SnapshotService))]
namespace Screenshot_Plugin
{

    //surprise
    /// <summary>
    /// Initializes a new instance of the <see cref="Screenshot"/> class.
    /// </summary>
    public class SnapshotService : ISnapShotService
    {

        /// <summary>
        ///  Method to take a screenshot,
        ///  <para>View = View of which the screenshot will be taken. Null defaults to the root of current xamarin.forms </para>
        ///  <para>Path = Path on the device where to save. Null defaults to root/pictures </para>
        ///  <para>Imagename = Name of the image + extension ".png" </para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="Path"></param>
        /// <param name="Imagename"></param>
        public void TakeScreenShot(View view = null)
        {
            var screenshotPath =
            Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
            Java.IO.File.Separator +
            "screenshot.png";

            var rootView = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView;

            using (var screenshot = Bitmap.CreateBitmap(
                    rootView.Width,
                    rootView.Height,
                    Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);
                rootView.Draw(canvas);

                using (var screenshotOutputStream = new System.IO.FileStream(
                            screenshotPath,
                            System.IO.FileMode.Create))
                {
                    screenshot.Compress(Bitmap.CompressFormat.Png, 90, screenshotOutputStream);
                    screenshotOutputStream.Flush();
                    screenshotOutputStream.Close();
                }
            }
        }
    }
}