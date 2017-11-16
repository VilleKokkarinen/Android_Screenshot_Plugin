// ---
// Open Source Screenshot Plugin for Xamarin.forms 
// 
// Ville Kokkarinen | @ | kokkarinen.ville@gmail.com
// 
// ---

using Android.App;
using Android.Views;
using Android.Graphics;

[assembly: Xamarin.Forms.Dependency(typeof(Screenshot_Plugin.SnapshotService))]
namespace Screenshot_Plugin
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnapshotService"/> class.
    /// </summary>
    public class SnapshotService : ISnapShotService
    {
        /// <summary>
        /// Generate this service and call it to take a snapshot
        /// <para> Or call directly with: </para>
        /// DependencyService.Get&lt;ISnapShotService>().TakeSnapShot()
        /// </summary>
        public SnapshotService() { }


        /// <summary>
        ///  Method to take a screenshot,
        ///  <para>View = View of which the screenshot will be taken. Null defaults to the root of current xamarin.forms </para>
        ///  <para>Path = Path on the device where to save. Null defaults to root/pictures </para>
        ///  <para>Imagename = Name of the image + extension ".png" </para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="path"></param>
        /// <param name="Imagename"></param>
        public void TakeSnapShot(View view = null, string path=null, string Imagename=null)
        {
            if(view == null)
                view = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView;

            if (path == null)
            {
                path = Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
                Java.IO.File.Separator + Imagename;                
            }

            using (var screenshot = Bitmap.CreateBitmap(
                    view.Width,
                    view.Height,
                    Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);
                view.Draw(canvas);

                using (var screenshotOutputStream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                {
                    screenshot.Compress(Bitmap.CompressFormat.Png, 90, screenshotOutputStream);
                    screenshotOutputStream.Flush();
                    screenshotOutputStream.Close();
                }
            }
        }
    }
}