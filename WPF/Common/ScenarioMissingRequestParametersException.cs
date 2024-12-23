using WPF.Models.Scenarious;

namespace WPF.Common
{
    class ScenarioMissingRequestParametersException : Exception
    {
        public BaseScenario Scenario { get; }
        public ScenarioMissingRequestParametersException(BaseScenario scenario)
        {
            Scenario = scenario;
        }

        public ScenarioMissingRequestParametersException(string? message, BaseScenario scenario) : base(message)
        {
            Scenario = scenario;
        }

        public ScenarioMissingRequestParametersException(string? message, Exception? innerException, BaseScenario scenario) : base(message, innerException)
        {
            Scenario = scenario;
        }
    }
}
