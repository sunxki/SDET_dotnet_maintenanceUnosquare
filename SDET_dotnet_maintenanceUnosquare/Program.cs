using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//input[@class='gLFyf gsfi']");
        By GoogleSearIcon = By.XPath("//div[@class='FPdoLc lJ9FBc']//following::input[@class='gNO89b']");
        By UnoSquareGoogleResult = By.XPath("//div//following::h3[@class='LC20lb DKV0Md' and contains(text(),'Unosquare: Digital Transformation Services | Agile')]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//a[@class='nav-link' and text()='Services']");
        By PracticeAreas = By.XPath("//a[@class='nav-link' and text()='Practice Areas']");
        By ContactUs = By.XPath("//a[contains(@class,'nav-link') and text()='Contact Us']");
        #endregion 
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");

            element = Browser.FindElement(program.GoogleSearIcon);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            element = Browser.FindElement(program.ContactUs);

            program.Click(element);
            Browser.Close();
        }
    }
}
