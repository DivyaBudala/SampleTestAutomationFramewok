using SampleTestAutomationFramework.Drivers;

namespace SampleTestAutomationFramework.FrameworkUtilities
{
    [Binding]
    public sealed class WebDriverUtil
    {
        private IWebDriver _driver;

        public WebDriverUtil(DriverFactory driverFactory)
        {
            _driver = driverFactory.GetWebDriver();
        }

        /// <summary>
        /// Function to pause the execution for the specified time period
        /// </summary>
        /// <param name="milliSeconds"></param>
        /// <param name="elementName"></param>
        /// <param name="elementType"></param>
        /// <exception cref="Exception"></exception>
        public void WaitFor(int milliSeconds, string elementName, string pageName)
        {
            try
            {
                Thread.Sleep(milliSeconds);
            }catch (Exception ex)
            {
                throw new Exception($"Error - Unable to wait for element '{elementName}' : {ex.Message}");
            }
        }

        public bool WaitUntilElementLocated(By locator, int timeOutInSeconds, string elementName, string pageName)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds)).Until(ExpectedConditions.ElementExists(locator));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - {elementName} is not found in the page {pageName} even after waiting for {timeOutInSeconds} Seconds with error : '{ex.Message}'");
            }
        }
    }
}
