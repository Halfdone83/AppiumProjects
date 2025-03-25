using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ColorNoteApp
{
    public class NotePOMTests
    {

        private AndroidDriver driver;
        private NotePOM notePOM;



        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            var appiumOptions = new AppiumOptions();
            appiumOptions.AutomationName = "UiAutomator2";
            appiumOptions.PlatformName = "Android";
            appiumOptions.PlatformVersion = "16";
            appiumOptions.DeviceName = "Appium Test";
            appiumOptions.App = "C:\\Users\\Halfdone\\Desktop\\QA Course\\Automation\\FrontEndQA\\FrontEndAutomationTesting\\10.Exercise Appium Mobile - Part 1\\Resources\\Notepad.apk";
            appiumOptions.AddAdditionalAppiumOption("autoGrantPermissions", "true");


            driver = new AndroidDriver(appiumOptions);

            notePOM = new NotePOM(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            notePOM.SkipTutorial();           
        }


        [Test]
        public void CreateNewNote()
        {
            var title = "NewNote";

            notePOM.AddNote(title);
                       
           Assert.That(notePOM.NoteTitle(title).Displayed, Is.True);   
        }

        [Test]
        public void EditNote()
        {
            var title = "NewNote2";

            notePOM.AddNote(title);

            Assert.That(notePOM.NoteTitle(title).Displayed, Is.True);

            notePOM.NoteTitle(title).Click();
           
            notePOM.EditNote();

            notePOM.NoteField.Clear();
            notePOM.WriteText("Edited");

            notePOM.BackButton.Click();
            notePOM.BackButton.Click();

            Assert.That(notePOM.NoteTitle("Edited").Displayed, Is.True);
            


        }

        [Test]
        public void DeleteNote()
        {
            var title = "NewNote3";

            notePOM.AddNote(title);

            Assert.That(notePOM.NoteTitle(title).Displayed, Is.True);

            notePOM.NoteTitle(title).Click();

            notePOM.MoreOptions();
            notePOM.DeleteNote();
            notePOM.ConfirmDelete();
                        
            Assert.That(notePOM.NoteTitleDeleted(title), Is.Empty);
        }



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
