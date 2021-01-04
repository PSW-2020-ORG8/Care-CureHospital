using E2ETests.WebAppPatientE2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace E2ETests.WebAppPatientE2ETests
{
    public class CancelAppointmentTest : IDisposable
    {
        private readonly IWebDriver driver;
        private PatientAppointmentsPage patientAppointmentsPage;
        private int patientAppointmentsCount = 0;
        private UserLoginPage userLoginPage;
        private PatientHomePage patientHomePage;

        public CancelAppointmentTest()
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
            userLoginPage.InsertUsername("pera");
            userLoginPage.InsertPassword("123");
            userLoginPage.SubmitForm();
            userLoginPage.WaitForPatientHomePage();

            patientHomePage = new PatientHomePage(driver);
            patientHomePage.Navigate();
            Assert.True(patientHomePage.AppointmetsLinkElementDisplayed());
            Assert.Equal(driver.Url, PatientHomePage.URI);
            patientHomePage.ClickAppointmentsLink();
            patientHomePage.WaitForAppointmentsPage();

            patientAppointmentsPage = new PatientAppointmentsPage(driver);
            patientAppointmentsPage.Navigate();
            patientAppointmentsPage.EnsurePageIsDisplayed();
            patientAppointmentsCount = patientAppointmentsPage.PatientAppointmentsCount();
            Assert.Equal(driver.Url, PatientAppointmentsPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulCancelAppointment()
        {
            if (patientAppointmentsPage.IsCancelAppointmentButtonNull())
            {
                Assert.True(true);
                return;
            }
            patientAppointmentsPage.ClickCancelAppointmentButton();

            patientHomePage.ClickAppointmentsLink();
            patientHomePage.WaitForAppointmentsPage();

            PatientAppointmentsPage newPatientAppointmentsPage = new PatientAppointmentsPage(driver);
            newPatientAppointmentsPage.EnsurePageIsDisplayed();

            Assert.Equal(patientAppointmentsCount - 1, newPatientAppointmentsPage.PatientAppointmentsCount());
        }
    }
}
