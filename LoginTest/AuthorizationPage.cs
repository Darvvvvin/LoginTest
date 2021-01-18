using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginTest
{
    class AuthorizationPage
    {
        private IWebDriver _webdriver;

        private readonly By _loginField = By.XPath("//input[@name='login' and@tabindex='2']");
        private readonly By _passwordField = By.XPath("//fieldset//input[@name='pass' and @tabindex='2']");
        private readonly By _enterButton = By.XPath("//form//input[@type='submit' and @tabindex='2' ]");

        public AuthorizationPage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public MainPage Login(string login, string password)
        {
            _webdriver.FindElement(_loginField).SendKeys(login);
            _webdriver.FindElement(_passwordField).SendKeys(password);
            _webdriver.FindElement(_enterButton).Click();

            return new MainPage(_webdriver);
        }
    }
}
