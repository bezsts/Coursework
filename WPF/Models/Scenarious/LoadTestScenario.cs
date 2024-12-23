using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using WPF.Models.Requests;

namespace WPF.Models.Scenarious
{
    class LoadTestScenario : BaseScenario
    {
        public LoadTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
            : base(name, max_rate, interval, duration) { }

        public LoadTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration, RequestParametres requestParametres)
            : base(name, max_rate, interval, duration, requestParametres) { }

        public override ScenarioProps Create()
        {
            return Scenario.Create("load_test_scenario", async context =>
            {
                var request = CreateRequest();
                var response = await Http.Send(_httpClient, request);
                return response;
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(10))
            .WithLoadSimulations(
                Simulation.RampingInject(rate: MaxRate,
                                         interval: Interval,
                                         during: Duration * 0.25),
                Simulation.Inject(rate: MaxRate,
                                  interval: Interval,
                                  during: Duration * 0.5),
                Simulation.RampingInject(rate: 0,
                                         interval: Interval,
                                         during: Duration * 0.25)
            );
        }
    }
}
