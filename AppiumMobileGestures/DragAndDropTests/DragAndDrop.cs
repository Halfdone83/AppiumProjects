using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace DragAndDropTests
{
    public class Tests
    {
        public AndroidDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
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
        public void DragAndDropTest()
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

            driver.FindElement(MobileBy.AccessibilityId("Drag and Drop")).Click();

            var cirlce1 = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_1"));

            var circle2 = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_2"));

            var script = new Dictionary<string, object>
            {
                {"elementId", cirlce1},
                {"endX", circle2.Location.X + (circle2.Size.Width / 2)},
                {"endY", circle2.Location.Y + (circle2.Size.Width / 2)},
                {"speed", 500} 
            };

            driver.ExecuteScript("mobile: dragGesture", script);

            Assert.That(driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_result_text")).Text, Is.EqualTo("Dropped!"));

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }   
    }
}