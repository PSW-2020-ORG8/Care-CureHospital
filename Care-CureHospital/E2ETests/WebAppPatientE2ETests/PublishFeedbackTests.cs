using E2ETests.WebAppPatientE2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace E2ETests.WebAppPatientE2ETests
{
    public class PublishFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private UserLoginPage userLoginPage;
        private PatientsFeedbacksPage patientsFeedbacksPage;
        private PublishedFeedbacksPage publishedFeedbacksPage;
        private int publishedFeedbacksCount = 0;

        public PublishFeedbackTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");     
            options.AddArguments("disable-infobars");         
            options.AddArguments("--disable-extensions");    
            options.AddArguments("--disable-gpu");            
            options.AddArguments("--disable-dev-shm-usage");  
            options.AddArguments("--no-sandbox");              
            options.AddArguments("--disable-notifications");  

            driver = new ChromeDriver(options);

            userLoginPage = new UserLoginPage(driver);
            userLoginPage.Navigate();
            Assert.True(userLoginPage.UsernameElementDisplayed());
            Assert.True(userLoginPage.PasswordElementDisplayed());
            Assert.True(userLoginPage.SubmitButtonElementDisplayed());
            userLoginPage.InsertUsername("admin1");
            userLoginPage.InsertPassword("admin1");
            userLoginPage.SubmitForm();
            userLoginPage.WaitForAdministratorHomePage();

            patientsFeedbacksPage = new PatientsFeedbacksPage(driver);
            Assert.True(patientsFeedbacksPage.PublishedFeedbacksLinkElementDisplayed());
            Assert.Equal(driver.Url, PatientsFeedbacksPage.URI);
            patientsFeedbacksPage.ClickPublishedFeedbacksLink();
            patientsFeedbacksPage.WaitForPublishedFeedbacksPage();

            publishedFeedbacksPage = new PublishedFeedbacksPage(driver);
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbacksCount = publishedFeedbacksPage.PublishedFeedbackCount();
            Assert.Equal(driver.Url, PublishedFeedbacksPage.URI);
            publishedFeedbacksPage.ClickAllFeedbacksLink();
            publishedFeedbacksPage.WaitForAllFeedbacksPage();

            patientsFeedbacksPage = new PatientsFeedbacksPage(driver);
            Assert.True(patientsFeedbacksPage.PublishFeedbackButtonDisplayed());
            Assert.Equal(driver.Url, PatientsFeedbacksPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulPublishFeedback()
        {
            patientsFeedbacksPage.ClickPublishFeedbackButton();
            patientsFeedbacksPage.ClickPublishedFeedbacksLink();
            patientsFeedbacksPage.WaitForPublishedFeedbacksPage();

            PublishedFeedbacksPage newPublishedFeedbacksPage = new PublishedFeedbacksPage(driver);
            newPublishedFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(publishedFeedbacksCount + 1, newPublishedFeedbacksPage.PublishedFeedbackCount());                                
        }
    }
}
