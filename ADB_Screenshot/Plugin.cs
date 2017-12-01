using System;
using System.Linq;
using System.Text;
using NUnit;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ADB_Screenshot
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                 AttributeTargets.Interface | AttributeTargets.Assembly,
                 AllowMultiple = true)]
    public class ScreenshotAttributeAttribute : Attribute, ITestAction
    {      
        public ScreenshotAttributeAttribute() {}

        public void BeforeTest(ITest test)
        {
          
        }

        public void AfterTest(ITest test)
        {
            ScreenCapture.Screenshot(Name: test.Name + ".png");
        }

        public ActionTargets Targets { get; } = ActionTargets.Test;
    }
}