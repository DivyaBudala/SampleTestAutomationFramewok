using AngleSharp.Dom;
using SampleTestAutomationFramework.Drivers;
using SampleTestAutomationFramework.FrameworkUtilities;
using SampleTestAutomationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleTestAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class HomeSteps
    {
        private IWebDriver _driver;        
        ControlFunctions _ctrlFunc;
        WebDriverUtil _driverUtil;

        public HomeSteps(DriverFactory driverFactory, ControlFunctions ctrlFunc, WebDriverUtil driverUtil)
        {
            _driver = driverFactory.GetWebDriver();
            _ctrlFunc = ctrlFunc;
            _driverUtil = driverUtil;
        }

        [Given(@"User open the url ""([^""]*)""")]
        public void GivenUserOpenTheUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);            
        }

        [When(@"I add four random items to my cart")]
        public void WhenIAddFourRandomItemsToMyCart()
        {
            _ctrlFunc.ScrollInToView(_driver.FindElement(HomePage.AddToCart), 10, HomePage.AddToCartButton);
           
            List<IWebElement> elements = _ctrlFunc.FindMultipleElements(HomePage.AddToCart, 10, HomePage.AddToCartButton);
            _driverUtil.WaitFor(2000, HomePage.AddToCartButton, HomePage.PageName);

            for(int i = 0; i < 4; i++)
            {
                _ctrlFunc.ScrollInToView(elements[i], 10, HomePage.AddToCartButton);
                _ctrlFunc.Click(elements[i], 20, HomePage.AddToCartButton);
                _driverUtil.WaitFor(1000, HomePage.AddToCartButton, HomePage.PageName);
            }            
        }

        [When(@"I view my Cart")]
        public void WhenIViewMyCart()
        {
            _ctrlFunc.ScrollInToView(_driver.FindElement(HomePage.ViewCart), 10,HomePage.ViewCartButton);
            _driverUtil.WaitFor(1000,HomePage.ViewCartButton, HomePage.PageName);

            _ctrlFunc.Click(HomePage.ViewCart, 10, HomePage.ViewCartButton);
            _driverUtil.WaitFor(2000, HomePage.ViewCartButton, HomePage.PageName);
        }

    }
}
