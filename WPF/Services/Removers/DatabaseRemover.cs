
using WPF.DbContexts;
using WPF.DTOs;
using WPF.Models.Requests;
using WPF.Models.Scenarious;

namespace WPF.Services.Removers
{
    public class DatabaseRemover : IRequestRemover, IScenarioRemover
    {
        private readonly DataModelContextFactory _dbContextFactory;

        public DatabaseRemover(DataModelContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task DeleteRequest(RequestParametres requestParametres)
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                RequestParametresDTO requestParametresDTO = ToRequestParametresDTO(requestParametres);

                context.Set<RequestParametresDTO>().Remove(requestParametresDTO);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteScenario(BaseScenario scenario)
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                ScenarioDTO scenarioDTO = ToScenarioDTO(scenario);

                context.Set<ScenarioDTO>().Remove(scenarioDTO);
                await context.SaveChangesAsync();
            }
        }

        private RequestParametresDTO ToRequestParametresDTO(RequestParametres requestParametres)
        {
            return new RequestParametresDTO()
            {
                Id = requestParametres.Id,
                Name = requestParametres.Name,
                Method = requestParametres.Method,
                Url = requestParametres.Url,
                ContentType = requestParametres.ContentType,
                Body = requestParametres.Body
            };
        }

        private ScenarioDTO ToScenarioDTO(BaseScenario scenario)
        {
            return new ScenarioDTO()
            {
                Id = scenario.Id,
                Name = scenario.Name,
                MaxRate = scenario.MaxRate,
                Interval = scenario.Interval,
                Duration = scenario.Duration,
                RequestParametresId = scenario.RequestParametres.Id,
                Type = scenario.TestType
            };
        }
    }
}
