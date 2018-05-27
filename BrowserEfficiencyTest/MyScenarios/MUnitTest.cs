using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace BrowserEfficiencyTest
{
    internal class MUnitTest : Scenario
    {
        public MUnitTest()
        {
            Name = "MUnitTest";
            DefaultDuration = 15;
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.NavigateToUrl("https://muni.cz");
            driver.WaitForPageLoad();
            
            driver.TypeIntoField(driver.FindElementById("search"), "Software Quality" + Keys.Enter);
            driver.WaitForPageLoad();
            driver.Wait(5);

            var elementToClick = driver.FindElementByXPath("//div[contains(@class, gsc-results)]" +
                                                            "/div[contains(@class, gsc-result)]" +
                                                            "/div[contains(@class, gs-result)]" +
                                                            "/div/div/a");
            driver.ClickElement(elementToClick);
            driver.WaitForPageLoad();
        }
    }
}
