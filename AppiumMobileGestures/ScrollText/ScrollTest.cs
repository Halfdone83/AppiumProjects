using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Internal;

namespace ScrollText
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
        public void TestScroll()
        {           
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

            var listMenu = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Lists\"))"));
            listMenu.Click();

            var firstItem = driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"01. Array\")"));

            Assert.IsTrue(firstItem.Displayed);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}