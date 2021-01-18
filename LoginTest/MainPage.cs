using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginTest
{
    class MainPage
    {
        private IWebDriver _webDriver;

        private readonly By _signInButton = By.XPath("//a[@onclick='return i_showFloat(1);']");
        private readonly By _userfield = By.XPath("//ul[@class='user_menu']//li[@class='first']");
        private readonly By _personalData = By.XPath("//a[@href='/form/']");

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
                      
                public AuthorizationPage SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new AuthorizationPage(_webDriver);
        }

        
        public PassportPage UserPassport()
        {
            _webDriver.FindElement(_userfield).Click();
            _webDriver.FindElement(_personalData).Click();

            return new PassportPage(_webDriver);
        }
    }
}
