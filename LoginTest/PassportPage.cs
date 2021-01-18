using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginTest
{
    class PassportPage
    {
        private IWebDriver _webDriver;
                
        private readonly By _firstNameField = By.XPath("//input[@name='fname']");
        private readonly By _lastNameField = By.XPath("//input[@name='lname']");
        private readonly By _sexUser = By.XPath("//select[@name='s']");
        private readonly By _saveButton = By.XPath("//input[@type='submit']");

        public PassportPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
              

        public void ChangesField(string firstName, string lastName)
        {
            
            _webDriver.FindElement(_firstNameField).Clear();
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            
            _webDriver.FindElement(_lastNameField).Clear();
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);

            _webDriver.FindElement(_saveButton).Click();

            _webDriver.Navigate().Refresh();

        }

        public  string GetTextUserFirstName()
        {
            string userFirstName = _webDriver.FindElement(_firstNameField).GetAttribute("value");

            return userFirstName;
        }
        public string GetTextUserLastName()
        {
            string userLastName = _webDriver.FindElement(_lastNameField).GetAttribute("value");

            return userLastName;
        }

    }
}
