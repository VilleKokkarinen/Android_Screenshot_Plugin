using Android.Views;
using Android.Graphics;

namespace Screenshot_Plugin
{
    public interface ISnapShotService
    {
        void TakeScreenShot(View view = null);
     
        
    }
}