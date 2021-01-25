using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class PatientsFeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://care-cure-gateway.herokuapp.com/index.html#/patientsFeedbacks";
        private IWebElement publishFeedbackButton => driver.FindElement(By.Id("publishFeedbackButton"));
        private IWebElement publishedFeedbacksLinkElement => driver.FindElement(By.Id("published-feedbacks-link"));
        private IWebElement maliciousPatientsLinkElement => driver.FindElement(By.Id("malicious-patients-link")); 

        public PatientsFeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool PublishFeedbackButtonDisplayed()
        {
            return publishFeedbackButton.Displayed;
        }

        public bool MaliciousPatientsLinkElementDisplayed()
        {
            return maliciousPatientsLinkElement.Displayed;
        }

        public bool PublishedFeedbacksLinkElementDisplayed()
        {
            return publishedFeedbacksLinkElement.Displayed;
        }

        public void ClickPublishFeedbackButton()
        {
            publishFeedbackButton.Click();
        }

        public void ClickMaliciousPatientsLink()
        {
            maliciousPatientsLinkElement.Click();
        }

        public void ClickPublishedFeedbacksLink()
        {
            publishedFeedbacksLinkElement.Click();
        }

        public void WaitForPublishedFeedbacksPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PublishedFeedbacksPage.URI));
        }

        public void WaitForPublishFeedbackButton()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("publishFeedbackButton")));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
