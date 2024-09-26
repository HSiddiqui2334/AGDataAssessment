using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDataUIAutomation.Pages
{
    [Binding]
    internal class HomePage
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;


        private IWebElement Company => driver.FindElement(By.XPath("//nav//div[@class='menu-main-menu-container']//a[./text()='Company']"));
        private IWebElement Overview => driver.FindElement(By.XPath("//nav[@class='main-navigation']//a[./text()='Overview']"));
        private IList<IWebElement> values => driver.FindElements(By.XPath("//div[./text()='Our Values']//parent::div//parent::section//following-sibling::section[1]//h3"));
        private IWebElement started => driver.FindElement(By.XPath("//a[contains(text(),'Get Started')]"));
        private IWebElement conatactPageForm => driver.FindElement(By.XPath("//div[@class='container']//p[contains(text(),'Fill out this form and we’ll be happy to contact you.')]"));

        public HomePage(ScenarioContext scenarioContext, IWebDriver driver)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        public void clickCompanyButton() { 
            Company.Click();
        }

        public void selectOverview() {
            Overview.Click();
        }
        public void listOfValues() {
            foreach (var item in values)
            {
                Console.WriteLine(item.Text);
            }
        }

        public void clickLestGetstarted() { 
        started.Click();
        }

        public void aseertContactPage() {
            driver.Url.Should().Contain("contact");
        }

        public void conatctPage() {
            conatactPageForm.Displayed.Should().BeTrue();
        }
    }
}
