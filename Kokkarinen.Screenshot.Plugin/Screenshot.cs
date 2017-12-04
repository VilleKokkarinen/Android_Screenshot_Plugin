using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kokkarinen.Screenshot.Plugin
{
    public class ScreenCapture
    {
        public ScreenCapture() { }

        /// <summary>
        /// Takes a screenshot over Android Device Bridge, and saves it to folder Screenshots/
        /// <para> Make sure you have ADB installed to location "C:/Program Files (x86)/Jenkins/tools/android-sdk/platform-tools/adb.exe" </para>
        /// </summary>
        /// <param name="PathInDevice"></param>
        /// <param name="Name"></param>
        public static void Screenshot(string PathInDevice = "/storage/emulated/0/Pictures/", string Name = "Screenshot.png")
        {           
                if (!System.IO.Directory.Exists("Screenshots"))
                    System.IO.Directory.CreateDirectory("Screenshots");

                Process Take_ADB_Screenshot = new Process();
                Take_ADB_Screenshot.StartInfo.FileName = "CMD.exe";              
                Take_ADB_Screenshot.StartInfo.Arguments =
                    "/c C:/Program Files (x86)/Jenkins/tools/android-sdk/platform-tools/adb shell screencap -p " + PathInDevice + Name
                    + " && C:/Program Files (x86)/Jenkins/tools/android-sdk/platform-tools/adb pull " + PathInDevice + Name + " Screenshots/" + Name;

                Take_ADB_Screenshot.Start();
                Take_ADB_Screenshot.Dispose();           
        }
    }
}