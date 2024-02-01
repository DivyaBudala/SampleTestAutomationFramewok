using SampleTestAutomationFramework.Drivers;

namespace SampleTestAutomationFramework.Hooks
{
    [Binding]
    public class SpecFlowHooks
    {
        private DriverFactory _driverFactory;

        public SpecFlowHooks(DriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverFactory.GetWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverFactory.CloseDriver();
        }
    }
}
