using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class PatientHomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/patientMainPage";
        private IWebElement appointmetsLinkElement => driver.FindElement(By.Id("appointments-link"));
        private IWebElement feedbacksLinkElement => driver.FindElement(By.Id("feedbacks-link"));

        public PatientHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool AppointmetsLinkElementDisplayed()
        {
            return appointmetsLinkElement.Displayed;
        }

        public bool FeedbacksLinkElementDisplayed()
        {
            return feedbacksLinkElement.Displayed;
        }

        public void WaitForPublishedFeedbacksPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PublishedFeedbacksPage.URI));
        }

        public void WaitForAppointmentsPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PatientAppointmentsPage.URI));
        }

        public void ClickAppointmentsLink()
        {
            appointmetsLinkElement.Click();
        }

        public void ClickFeedbacksLink()
        {
            feedbacksLinkElement.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
