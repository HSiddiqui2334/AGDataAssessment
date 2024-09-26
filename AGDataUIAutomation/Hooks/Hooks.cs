using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDataUIAutomation.Hooks
{
    [Binding]
    internal class Hooks
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;
        private readonly IObjectContainer objectContainer;

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            this.scenarioContext = scenarioContext;
            this.objectContainer = objectContainer;
        }

        public ScenarioContext Scenariocontext => this.scenarioContext;

        [BeforeScenario]
        public void Driverinitialization() {
             driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void Drivershutdown() {
            driver.Quit();
        }
    }
}
