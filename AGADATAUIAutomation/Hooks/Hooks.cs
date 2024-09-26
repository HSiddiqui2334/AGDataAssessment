using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGADATAUIAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        IWebDriver driver;

        [BeforeFeature]
        public void Driverinitialization() { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterFeature]
        public void Cleanup() 
        { 
            driver.Quit();
        }
    }
}
