using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;

namespace WPF.Models.Scenarious
{
    class SoakTestScenario : BaseScenario
    {
        public SoakTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
            : base(name, max_rate, interval, duration) { }

        public override ScenarioProps Create()
        {
            return Scenario.Create("soak_test_scenario", async context =>
            {
                var request = CreateRequest();
                var response = await Http.Send(_httpClient, request);
                return response;
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(10))
            .WithLoadSimulations(
                Simulation.RampingInject(rate: MaxRate,
                                         interval: Interval,
                                         during: Duration * 0.008),
                Simulation.Inject(rate: MaxRate,
                                  interval: Interval,
                                  during: Duration * 0.984),
                Simulation.RampingInject(rate: 0,
                                         interval: Interval,
                                         during: Duration * 0.008)
            );
        }
    }
}
