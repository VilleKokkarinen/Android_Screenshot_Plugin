using System;
using System.Linq;
using System.Text;
using NUnit;
using System.Reflection;
using NUnit.Framework;

namespace Kokkarinen.Screenshot.Plugin
{  

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                 AttributeTargets.Interface | AttributeTargets.Assembly,
                 AllowMultiple = true)]
    public class ScreenshotAttributeAttribute : Attribute, ITestAction
    {      
        public ScreenshotAttributeAttribute() {}

        public void BeforeTest(TestDetails test)
        {           
        }

        public void AfterTest(TestDetails test)
        {           
            ScreenCapture.Screenshot(Name: test.Method.Name + ".png");
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }
    }
}