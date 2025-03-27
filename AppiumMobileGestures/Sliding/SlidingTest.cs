using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Sliding
{
    public class Tests
    {
        public AndroidDriver driver;         

        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions
            {
                PlatformName = "Android",
                PlatformVersion = "16",
                AutomationName = "UiAutomator2",
                DeviceName = "Appium",
                App = "C:\\Users\\Halfdone\\Desktop\\QA Course\\Automation\\FrontEndQA\\FrontEndAutomationTesting\\11.Exercise Appium Mobile - Part 2\\Resources\\ApiDemos-debug.apk"
            };

            driver = new AndroidDriver(appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test()
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

            var seekBar = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Seek Bar\"))"));
            seekBar.Click();

            MoveSeekBar(641, 351, 1228, 300);               
           
            var result = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/progress"));
            
            Assert.That(result.Text, Is.EqualTo("100 from touch=true"));


        }

        public void MoveSeekBar(int startX, int startY, int endX, int endY)
        {
            var finger = new PointerInputDevice(PointerKind.Touch);
            var start = new Point(startX, startY);
            var end = new Point(endX, endY);

            var swipe = new ActionSequence(finger);

            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromSeconds(1)));
            swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { swipe });
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}