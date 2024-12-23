using NBomber.Contracts;
using System.Net.Http;
using WPF.Models.Requests;

namespace WPF.Models.Scenarious
{
    public abstract class BaseScenario
    {
        protected HttpClient _httpClient = new HttpClient();
        public int Id { get; init; }
        public string Name { get; set; }
        public int MaxRate { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan Duration { get; set; }
        public RequestParametres? RequestParametres { get; set; }

        protected BaseScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
        {
            Name = name;
            MaxRate = max_rate;
            Interval = interval;
            Duration = duration;
        }

        public abstract ScenarioProps Create();

        protected HttpRequestMessage CreateRequest()
        {
            var localRequestParametres = RequestParametres;
            var requestFactory = localRequestParametres != null ? RequestFactory.CreateFactory(localRequestParametres)
                                                            : throw new NullReferenceException("Request parametres are absent");
            return requestFactory();
        }
    }
}
