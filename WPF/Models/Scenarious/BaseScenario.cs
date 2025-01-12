﻿using NBomber.Contracts;
using System.Net.Http;
using WPF.Common.Enums;
using WPF.Common.Exceptions;
using WPF.DTOs;
using WPF.Models.Requests;

namespace WPF.Models.Scenarious
{
    public abstract class BaseScenario
    {
        protected HttpClient _httpClient = new HttpClient();
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxRate { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan Duration { get; set; }
        public RequestParametres? RequestParametres { get; set; }
        public abstract Tests TestType { get; }

        protected BaseScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
        {
            Name = name;
            MaxRate = max_rate;
            Interval = interval;
            Duration = duration;
        }

        protected BaseScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration, RequestParametres requestParametres)
            : this(name, max_rate, interval, duration)
        {
            RequestParametres = requestParametres;
        }

        protected BaseScenario(ScenarioDTO scenarioDTO, RequestParametres requestParametres)
        { 
            Id = scenarioDTO.Id;
            Name = scenarioDTO.Name;
            MaxRate = scenarioDTO.MaxRate;
            Interval = scenarioDTO.Interval;
            Duration = scenarioDTO.Duration;
            RequestParametres = requestParametres;
        }

        public abstract ScenarioProps Create();

        protected HttpRequestMessage CreateRequest()
        {
            var localRequestParametres = RequestParametres;
            var requestFactory = localRequestParametres != null ? RequestFactory.CreateFactory(localRequestParametres)
                                                            : throw new ScenarioMissingRequestParametersException(this);
            return requestFactory();
        }

        public bool IsRequestParametresExist()
        {
            return RequestParametres != null;
        }
    }
}
