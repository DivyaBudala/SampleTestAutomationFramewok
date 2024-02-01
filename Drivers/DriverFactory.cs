namespace SampleTestAutomationFramework.Drivers
{
    public class DriverFactory
    {
        public IWebDriver _driver;

        public IWebDriver GetWebDriver()
        {
            if (_driver == null)
            {
                var browserType = ConfigurationManager.AppSettings["Browser"];
                _driver = CreateWebDriverInstance(browserType);
            }
            _driver.Manage().Window.Maximize();
            return _driver;
        }


        public IWebDriver CreateWebDriverInstance(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    ChromeOptions options = new();
                    options.AddArgument("no-sandbox");

                    return new ChromeDriver();
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();
                default:
                    throw new Exception($"Undefined Browser Type - {browserType}");
            }
        }

        public void CloseDriver()
        {
            _driver?.Close();
            _driver?.Quit();
        }
    }
}
