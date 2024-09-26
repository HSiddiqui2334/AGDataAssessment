using AGDataUIAutomation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDataUIAutomation.StepDefinitions
{
    [Binding]
    internal class UIAutomationStepDefinition
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
       

        public UIAutomationStepDefinition(ScenarioContext scenarioContext, IWebDriver driver) 
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        private HomePage homePage => new HomePage(scenarioContext ,driver);


        [Given(@"user visits the url ""([^""]*)""")]
        public void GivenUserVisitsTheUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"user clicks on Company button")]
        public void GivenUserClicksOnCompanyButton()
        {
            homePage.clickCompanyButton();
        }

        [Given(@"user select the Overview option")]
        public void GivenUserSelectTheOverviewOption()
        {
            homePage.selectOverview();
        }

        [Then(@"user stores all the values in list")]
        public void ThenUserStoresAllTheValuesInList()
        {
            homePage.listOfValues();
        }

        [Given(@"user click let get started")]
        public void GivenUserClickLetGetStarted()
        {
            homePage.clickLestGetstarted();
        }

        [Then(@"validate contact page")]
        public void ThenValidateContactPage()
        {

        }


    }
}
