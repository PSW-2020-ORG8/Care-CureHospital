using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class BlockMaliciousPatientsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "https://care-cure-gateway.herokuapp.com/index.html#/blockMaliciousPatients";
        private IWebElement blockMaliciousPatientButton => driver.FindElement(By.ClassName("block-malicious-patient-btn"));
        private ReadOnlyCollection<IWebElement> patientsForBlocking => driver.FindElements(By.ClassName("patient-for-blocking"));
        private IWebElement blockedPatientTd => driver.FindElement(By.ClassName("blocked-patient-td"));
        private IWebElement maliciousPatientsLinkElement => driver.FindElement(By.Id("block-malicious-patients-link"));

        public BlockMaliciousPatientsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return BlockMaliciousPatientButtonDisplayed();
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

        public void EnsureTableDataIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return BlockMaliciousPatientTdDisplayed();
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

        public bool BlockMaliciousPatientButtonDisplayed()
        {
            return blockMaliciousPatientButton.Displayed;
        }

        public bool BlockMaliciousPatientTdDisplayed()
        {
            return blockedPatientTd.Displayed;
        }

        public void ClickBlockMaliciousPatientButton()
        {
            blockMaliciousPatientButton.Click();
        }

        public int PatientsForBlockingCount()
        {
            return patientsForBlocking.Count;
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public bool MaliciousPatientsLinkElementDisplayed()
        {
            return maliciousPatientsLinkElement.Displayed;
        }

        public void ClickMaliciousPatientsLink()
        {
            maliciousPatientsLinkElement.Click();
        }

        public void WaitForMaliciousPatientsPage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
