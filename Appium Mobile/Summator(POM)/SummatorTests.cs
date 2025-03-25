using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Summator_POM_
{
    public  class SummatorTests
    {

        private AndroidDriver driver;

        private SummatorPOM summatorPOM;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AutomationName = "UiAutomator2";
            appiumOptions.PlatformName = "Android";
            appiumOptions.PlatformVersion = "16";
            appiumOptions.DeviceName = "Appium Test";
            appiumOptions.App = "C:\\Users\\Halfdone\\Desktop\\QA Course\\Automation\\FrontEndQA\\FrontEndAutomationTesting\\10.Exercise Appium Mobile - Part 1\\Resources\\androidappsummator.apk";

            driver = new AndroidDriver(appiumOptions);
            summatorPOM = new SummatorPOM(driver);
        }


        [Test]
        public void ValidDataTest()
        { 
            var result = summatorPOM.CalculateSum("5", "5");
            Assert.That(result, Is.EqualTo("10"));       
        }

        [Test]
        public void InvalidDataTest()
        {
            var result = summatorPOM.CalculateSum("", "5");
            Assert.That(result, Is.EqualTo("error"));
        }



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}
