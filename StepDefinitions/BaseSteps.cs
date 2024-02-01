namespace SampleTestAutomationFramework.StepDefinitions
{
    public class BaseSteps
    {
        protected ScenarioContext _scenarioContext;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
