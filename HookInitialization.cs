using TechTalk.SpecFlow;

namespace SpecFlowProject2.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        public HookInitialization(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Saving environment variables for every tests
            Uri GetURL = new Uri("https://jsonplaceholder.typicode.com/posts");
            Uri PostURL = new Uri("https://jsonplaceholder.typicode.com/posts");
            _scenarioContext.Set(GetURL, "GetURL");
            _scenarioContext.Set(PostURL, "PostURL");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}