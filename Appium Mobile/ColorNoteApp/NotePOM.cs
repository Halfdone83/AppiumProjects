using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ColorNoteApp
{
    public class NotePOM
    {

        public AndroidDriver driver;

        public NotePOM(AndroidDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement AddNoteButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
        public IWebElement SkipButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));
        public IWebElement TextButton => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
        public IWebElement NoteField => driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/edit_note\"]"));
        public IWebElement NoteTitle(string text) => driver.FindElement(MobileBy.XPath($"//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\" and @text='{text}']"));
        public IReadOnlyCollection<IWebElement> NoteTitleDeleted(string text) => driver.FindElements(MobileBy.XPath($"//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/title\" and @text='{text}']"));
        public IWebElement BackButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        public IWebElement EditButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn"));
        public IWebElement MoreButton => driver.FindElement(MobileBy.XPath("//android.widget.ImageButton[@content-desc=\"More\"]"));
        public IWebElement DeleteButton => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")"));
        public IWebElement ConfirmDeleteButton => driver.FindElement(MobileBy.Id("android:id/button1"));


        
       
        public void SkipTutorial()
        {

            try
            {
                SkipButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void AddNote(string title)
        {            
            AddNoteButton.Click();
            TextButton.Click();
            NoteField.SendKeys(title);
            BackButton.Click();
            BackButton.Click();
        }

        public void CreateNote()
        {
            AddNoteButton.Click();
        }

        public void EditNote()
        {
            EditButton.Click();
        }

        public void DeleteNote()
        {            
            DeleteButton.Click();            
        }

       
        public void MoreOptions()
        {
            MoreButton.Click();
        }

        public void ConfirmDelete()
        {
            ConfirmDeleteButton.Click();
        }

        public void WriteText(string text)
        {
            NoteField.SendKeys(text);
        }


    }
}
