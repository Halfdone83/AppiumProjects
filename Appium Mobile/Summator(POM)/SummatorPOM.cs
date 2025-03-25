using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Summator_POM_
{
    public class SummatorPOM
    {
        private readonly AndroidDriver driver;

        public SummatorPOM(AndroidDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement firstField => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));

        public IWebElement secondField => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));

        public IWebElement calcButton => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));

        public IWebElement resultField => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        public string CalculateSum(string number1, string number2)
        {        
            firstField.Clear();
            firstField.SendKeys(number1);
            secondField.Clear();
            secondField.SendKeys(number2);
            calcButton.Click();   
            
            return resultField.Text;
        }



    }
}
