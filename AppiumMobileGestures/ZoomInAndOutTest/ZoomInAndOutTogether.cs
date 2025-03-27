using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

using OpenQA.Selenium.Interactions;


namespace ZoomInAndOutTogetherTest
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
        public void ZoomInTest()
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"WebView\"))")).Click();

            ZoomIn(493, 740, 493, 493, 493, 900, 493, 1100);

            ZoomOut(493, 493, 493, 740, 493, 1100, 493, 900);


        }

        public void ZoomIn(int startXf1, int srartYf1, int endXf1, int endYf1, int startXf2, int srartYf2, int endXf2, int endYf2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomInf1 = new ActionSequence(finger1);

            zoomInf1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startXf1, srartYf1, TimeSpan.Zero));
            zoomInf1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomInf1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endXf1, endYf1, TimeSpan.FromMilliseconds(1500)));
            zoomInf1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomInf2 = new ActionSequence(finger2);

            zoomInf2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startXf2, srartYf2, TimeSpan.Zero));
            zoomInf2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomInf2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endXf2, endYf2, TimeSpan.FromMilliseconds(1500)));
            zoomInf2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomInf1, zoomInf2 });
        }
        public void ZoomOut(int startXf1, int srartYf1, int endXf1, int endYf1, int startXf2, int srartYf2, int endXf2, int endYf2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomOutf1 = new ActionSequence(finger1);
            zoomOutf1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startXf1, srartYf1, TimeSpan.Zero));
            zoomOutf1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomOutf1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endXf1, endYf1, TimeSpan.FromMilliseconds(1500)));
            zoomOutf1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomOutf2 = new ActionSequence(finger2);
            zoomOutf2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startXf2, srartYf2, TimeSpan.Zero));
            zoomOutf2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomOutf2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endXf2, endYf2, TimeSpan.FromMilliseconds(1500)));
            zoomOutf2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomOutf1, zoomOutf2 });

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}