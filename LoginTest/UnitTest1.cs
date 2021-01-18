using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace LoginTest
{
    public class Tests
    {
        private IWebDriver _webdriver;
        private string _expectedUserFirstName = "John";
        private string _expectedUserLastName = "Wick";
        [SetUp]
        public void Setup()
        {
            _webdriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webdriver.Navigate().GoToUrl("https://www.i.ua/");
            _webdriver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            
            var mainMenu = new MainPage(_webdriver);
            mainMenu
                .SignIn()
                .Login("hunda_teodor@ukr.net", "Automationisacool")
                .UserPassport()
                .ChangeField("John", "Wick");
            var user = new PassportPage(_webdriver);
            string actualUserFirstName = user.GetTextUserFirstName();
            string actualUserLastName = user.GetTextUserLastName();

            Assert.AreEqual(_expectedUserFirstName, actualUserFirstName);
            Assert.AreEqual(_expectedUserLastName, actualUserLastName);
                                  
                
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}