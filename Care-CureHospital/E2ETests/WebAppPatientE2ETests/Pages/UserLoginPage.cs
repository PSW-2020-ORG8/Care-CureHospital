using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class UserLoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/userLogin";
        private IWebElement usernameElement => driver.FindElement(By.Id("username-input"));
        private IWebElement passwordElement => driver.FindElement(By.Id("password-input"));
        private IWebElement submitButtonElement => driver.FindElement(By.Id("sign-in-button"));

        public UserLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool UsernameElementDisplayed()
        {
            return usernameElement.Displayed;
        }

        public bool PasswordElementDisplayed()
        {
            return passwordElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return submitButtonElement.Displayed;
        }

        public void InsertUsername(string username)
        {
            usernameElement.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            passwordElement.SendKeys(password);
        }

        public void SubmitForm()
        {
            submitButtonElement.Click();
        }

        public void WaitForPatientHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PatientHomePage.URI));
        }

        public void WaitForAdministratorHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PatientsFeedbacksPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
