using Android.Views;
using Android.Graphics;
using System.Threading.Tasks;

namespace Screenshot_Plugin
{
    /// <summary>
    /// Interface for taking a snapshot of the current view
    /// </summary>
    public interface ISnapShotService
    {
        

        /// <summary>
        /// Returns current screen as a byte[] (image), doesn't save it.
        /// </summary>
        /// <returns></returns>
        byte[] CurrentScreenBytes(View view = null);
               
        /// <summary>
        ///  Method to take a screenshot and save to device.             
        ///  <para>View = View of which the screenshot will be taken. Null defaults to the root of current xamarin.forms </para>
        ///  <para>   Path = Path on the device where to save. Null defaults to root/pictures </para>
        ///  <para>Imagename = Name for Screenshot file + extension ".png" / ".jpeg" / ".jpg" </para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="path"></param>
        /// <param name="Imagename"></param>
        void SaveScreenShot(View view = null, string path = null, string Imagename = null);        
    }
}