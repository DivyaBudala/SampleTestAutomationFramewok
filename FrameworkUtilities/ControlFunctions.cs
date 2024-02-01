using SampleTestAutomationFramework.Drivers;

namespace SampleTestAutomationFramework.FrameworkUtilities
{
    [Binding]
    public sealed class ControlFunctions
    {
        private IWebDriver _driver;        
        public ControlFunctions(DriverFactory driverFactory)
        {
            _driver = driverFactory.GetWebDriver();            
        }

        /// <summary>
        ///  Function to input the value using sendkeys   
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="Text"></param>
        /// <param name="elementName"></param>
        /// <exception cref="Exception"></exception>
        public void SendKeys(By locator, long timeOutInSeconds, string Text, string elementName)
        {
            try
            {
                _driver.FindElement(locator).SendKeys(Text);
            }
            catch (Exception e)
            {
                throw new Exception($"Exception on enter text in the field {elementName} - {e.Message}");
            }
        }

        /// <summary>
        /// Function to perform click on element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="elementName"></param>
        /// <exception cref="Exception"></exception>
        public void Click(By locator, long timeOutInSeconds, string elementName)
        {
            try
            {

                _driver.FindElement(locator).Click();
            }catch (Exception e)
            {
                throw new Exception($"Exception on perform click on {elementName} : {e.Message}");
            }
        }

        /// <summary>
        /// Function to perform click on element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="elementName"></param>
        /// <exception cref="Exception"></exception>
        public void Click(IWebElement element, long timeOutInSeconds, string elementName)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Exception on perform click on {elementName} : {e.Message}");
            }
        }

        /// <summary>
        /// Function to find multiple elements on a page
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="elementName"></param>
        /// <returns>A list of IWebElements matching the current criteria</returns>
        /// <exception cref="Exception"></exception>
        public List<IWebElement> FindMultipleElements(By locator, long timeOutInSeconds, string elementName)
        {
            try
            {
                return _driver.FindElements(locator).ToList<IWebElement>(); 
            }
            catch (Exception e)
            {
                throw new Exception($"Exception on perform click on {elementName} : {e.Message}");
            }
        }

        /// <summary>
        /// Function to Scroll into view to an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="elementName"></param>
        /// <exception cref="Exception"></exception>
        public void ScrollInToView(IWebElement element, long timeOutInSeconds, string elementName)
        {
            try
            {
                IJavaScriptExecutor scriptExecutor = (IJavaScriptExecutor)_driver;
                scriptExecutor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'})", element);                
            }
            catch (Exception e)
            {
                throw new Exception($"Exception on performing Scroll Into View on {elementName} : {e.Message}");
            }
        }

    }
}
