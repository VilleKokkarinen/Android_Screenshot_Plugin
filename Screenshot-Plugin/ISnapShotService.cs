using Android.Views;
using Android.Graphics;

namespace Screenshot_Plugin
{
    /// <summary>
    /// Interface for taking a snapshot of the current view
    /// </summary>
    public interface ISnapShotService
    {
        /// <summary>
        ///  Method to take a screenshot.              
        ///  <para>View = View of which the screenshot will be taken. Null defaults to the root of current xamarin.forms </para>
        ///  <para>   Path = Path on the device where to save. Null defaults to root/pictures </para>
        ///  <para>Imagename = Name for Screenshot file + extension ".png" / ".jpeg" / ".jpg" </para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="path"></param>
        /// <param name="Imagename"></param>
        void TakeSnapShot(View view = null, string path = null, string Imagename = null);        
    }
}