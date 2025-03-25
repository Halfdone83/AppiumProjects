using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace ColorNoteApp
{
    public class Tests
    {

        public AndroidDriver driver;

              
        [OneTimeSetUp]
        public void OneTimeSetup()
        {

            var appiumOptions = new AppiumOptions();
            appiumOptions.AutomationName = "UiAutomator2";
            appiumOptions.PlatformName = "Android";
            appiumOptions.PlatformVersion = "16";
            appiumOptions.DeviceName = "Appium Test";
            appiumOptions.App = "C:\\Users\\Halfdone\\Desktop\\QA Course\\Automation\\FrontEndQA\\FrontEndAutomationTesting\\10.Exercise Appium Mobile - Part 1\\Resources\\Notepad.apk";
            appiumOptions.AddAdditionalAppiumOption("autoGrantPermissions", "true");

            driver = new AndroidDriver(appiumOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip")).Click();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        [Test]
        public void CreateNewNote()
        {
            driver.FindElement(MobileBy.XPath("//android.widget.ImageButton[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/main_btn1\"]")).Click();

            driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")")).Click();

            driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]")).SendKeys("Test Note");

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            var note = driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\"]"));

            Assert.That(note.Text, Is.EqualTo("Test Note"));
        }

        [Test]
        public void EditNote()
        {
            driver.FindElement(MobileBy.XPath("//android.widget.ImageButton[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/main_btn1\"]")).Click();

            driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")")).Click();

            driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]")).SendKeys("Test Note");

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            var note = driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\"]"));

            Assert.That(note.Text, Is.EqualTo("Test Note"));



            driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\" and @text='Test Note']")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn")).Click();
           
            driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]")).Clear();
            driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]")).SendKeys("Edited");

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            var editedNote = driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\" and @text='Edited']"));

            Assert.That(editedNote.Text, Is.EqualTo("Edited"));


        }

        [Test]
        public void DeleteNote()
        {
            driver.FindElement(MobileBy.XPath("//android.widget.ImageButton[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/main_btn1\"]")).Click();

            driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")")).Click();

            driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]")).SendKeys("Test Note");

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn")).Click();

            var note = driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\"]"));

            Assert.That(note.Text, Is.EqualTo("Test Note"));



            driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\" and @text='Test Note']")).Click();

            driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn")).Click();
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")")).Click();
            driver.FindElement(MobileBy.Id("android:id/button1")).Click();

            var notes = driver.FindElements(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

            Assert.That(notes.Count, Is.EqualTo(0));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        

    }
}