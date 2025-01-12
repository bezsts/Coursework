﻿using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using WPF.Common.Enums;
using WPF.DTOs;
using WPF.Models.Requests;

namespace WPF.Models.Scenarious
{
    class SoakTestScenario : BaseScenario
    {
        public override Tests TestType { get { return Tests.Soak; } }

        public SoakTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
            : base(name, max_rate, interval, duration) { }

        public SoakTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration, RequestParametres requestParametres)
            : base(name, max_rate, interval, duration, requestParametres) { }

        public SoakTestScenario(ScenarioDTO scenarioDTO, RequestParametres requestParametres)
            : base(scenarioDTO, requestParametres) { }

        public override ScenarioProps Create()
        {
            return Scenario.Create("soak_test_scenario", async context =>
            {
                var request = CreateRequest();
                var response = await Http.Send(_httpClient, request);
                return response;
            })
            .WithoutWarmUp()
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
