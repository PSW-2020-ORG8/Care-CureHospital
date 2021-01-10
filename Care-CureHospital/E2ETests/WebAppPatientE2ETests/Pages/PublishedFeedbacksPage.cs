using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class PublishedFeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:60370/index.html#/";
        private ReadOnlyCollection<IWebElement> publishedFeedbacks => driver.FindElements(By.XPath("//div[@class='feedback-info']"));
        private IWebElement postFeedbackLinkElement => driver.FindElement(By.Id("post-feedback-link"));
        private IWebElement allFeedbacksLinkElement => driver.FindElement(By.Id("all-feedbacks-link"));

        public PublishedFeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return publishedFeedbacks.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public bool PostFeedbackLinkElementDisplayed()
        {
            return postFeedbackLinkElement.Displayed;
        }

        public bool AllFeedbacksLinkElementDisplayed()
        {
            return allFeedbacksLinkElement.Displayed;
        }

        public void ClickPostFeedbackLink()
        {
            postFeedbackLinkElement.Click();
        }

        public void ClickAllFeedbacksLink()
        {
            allFeedbacksLinkElement.Click();
        }

        public int PublishedFeedbackCount()
        {
            return publishedFeedbacks.Count;
        }

        public void WaitForAllFeedbacksPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PatientsFeedbacksPage.URI));
        }

        public void WaitForPostFeedbacksPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PostFeedbackPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
