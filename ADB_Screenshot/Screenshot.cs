using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_Screenshot
{
    public class ScreenCapture
    {
        public static void Screenshot(string PathInDevice = "/storage/emulated/0/Pictures/", string Name = "Screenshot.png")
        {
            if (!System.IO.Directory.Exists("Screenshots"))
                System.IO.Directory.CreateDirectory("Screenshots");

            Process Take_ADB_Screenshot = new Process();
            Take_ADB_Screenshot.StartInfo.FileName = "CMD.exe";
            Take_ADB_Screenshot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Take_ADB_Screenshot.StartInfo.Arguments =
                "/c cd ADB && adb shell screencap -p " +
                PathInDevice + Name + " && adb pull " +
                PathInDevice + Name + " ../Screenshots/" + Name;

            Take_ADB_Screenshot.Start();
            Take_ADB_Screenshot.Dispose();            
        }
    }
}