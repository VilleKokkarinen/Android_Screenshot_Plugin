// ---
// Open Source Screenshot Plugin for Xamarin.forms 
// 
// Ville Kokkarinen | @ | kokkarinen.ville@gmail.com
// 
// ---

using Android.App;
using Android.Views;
using Android.Graphics;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Screenshot_Plugin.SnapshotService))]
namespace Screenshot_Plugin
{



    /// <summary>
    /// Initializes a new instance of the <see cref="SnapshotService"/> class.
    /// </summary>
    public class SnapshotService : ISnapShotService
    {
        /// <summary>
        /// You must enter this activity at your Mainactivity
        /// </summary>
        public static Activity Activity { get; set; }

        /// <summary>
        /// Returns bytes of current screen for further processing
        /// </summary>
        /// <returns></returns>
        public byte[] CurrentScreenBytes()
        {
            if (Activity == null)
            {
                throw new Exception("You have to set ScreenshotManager.Activity in your Android project");
            }

            var view = Activity.Window.DecorView;
            view.DrawingCacheEnabled = true;

            Bitmap bitmap = view.GetDrawingCache(true);

            byte[] bitmapData;

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            return bitmapData;
        }


        /// <summary>
        /// Saves the file to your C: drive
        /// </summary>
        /// <param name="image"></param>
        public void SaveToPC(byte[] image)
        {
            File.WriteAllBytes(Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
                Java.IO.File.Separator + "image.png", image);
        }
        /// <summary>
        /// Generate this service and call TakeSnapShot to take a snapshot from the current view
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
        public void SaveCurrentScreenToDevice(View view = null, string path=null, string Imagename=null)
        {


            if (view == null)
                view = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView;



            if (path == null)
            {
                // Path => (Root)/Pictures/Image.png
                path = Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
                Java.IO.File.Separator + Imagename;                
            }



            //Creates a bitmap of the current view
            using (var screenshot = Bitmap.CreateBitmap(
                    view.Width,
                    view.Height,
                    Bitmap.Config.Argb8888))
            {


                //Draws a canvas of the current screen
                var canvas = new Canvas(screenshot);
                view.Draw(canvas);



                //Compresses the screenshot and saves it to the device
                using (var screenshotOutputStream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                {
                    screenshot.Compress(Bitmap.CompressFormat.Png, 90, screenshotOutputStream);
                    screenshotOutputStream.Flush();                   
                }
            }
        }
    }
}