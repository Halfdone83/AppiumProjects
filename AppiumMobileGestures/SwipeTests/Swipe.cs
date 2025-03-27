using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;

namespace SwipeTests
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
        public void SwipeTest()
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

            driver.FindElement(MobileBy.AccessibilityId("Gallery")).Click();

            driver.FindElement(MobileBy.AccessibilityId("1. Photos")).Click();

            var firstImage = driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[0];

            var actions = new Actions(driver);

            var swipe = actions.ClickAndHold(firstImage).MoveByOffset(-200, 0).Release().Build();

            swipe.Perform();

            Assert.That(driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[2].Displayed);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}