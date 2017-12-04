using System;
using System.Linq;
using System.Text;
using System.Reflection;
using NUnit.Framework;
using System.Diagnostics;

namespace Kokkarinen.Screenshot.Plugin
{
    /// <summary>
    /// Runs methods before and after a test, or all tests in a testfixture /// usage: [TestFixture] [ScreenshotAttribute]
    /// <para> Can be used seperately for each test, a whole testfixture, or both. </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                 AttributeTargets.Interface | AttributeTargets.Assembly,
                 AllowMultiple = true)]
    public class ScreenshotAttributeAttribute : Attribute, ITestAction
    {      
        public ScreenshotAttributeAttribute() {}

        /// <summary>
        /// Runs *BEFORE* the test.
        /// </summary>
        /// <param name="test"></param>
        public void BeforeTest(TestDetails test)
        {           
        }

        /// <summary>
        /// Runs *AFTER* the test.
        /// </summary>
        /// <param name="test"></param>
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