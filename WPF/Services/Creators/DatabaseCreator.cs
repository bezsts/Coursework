using WPF.Common.Enums;
using WPF.DbContexts;
using WPF.DTOs;
using WPF.Models.Requests;
using WPF.Models.Scenarious;

namespace WPF.Services.Creators
{
    public class DatabaseCreator : IRequestCreator, IScenarioCreator
    {
        private readonly DataModelContextFactory _dbContextFactory;

        public DatabaseCreator(DataModelContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateRequest(RequestParametres requestParametres)
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                RequestParametresDTO requestParametresDTO = ToRequestParametresDTO(requestParametres);

                context.Set<RequestParametresDTO>().Add(requestParametresDTO);
                await context.SaveChangesAsync();
            }
        }

        private RequestParametresDTO ToRequestParametresDTO(RequestParametres requestParametres)
        {
            return new RequestParametresDTO() 
            {
                Name  = requestParametres.Name,
                Method  = requestParametres.Method,
                Url  = requestParametres.Url,
                ContentType  = requestParametres.ContentType,
                Body  = requestParametres.Body
            };
        }

        public async Task CreateScenario(BaseScenario scenario)
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                ScenarioDTO scenarioDTO = ToScenarioDTO(scenario);

                context.Set<ScenarioDTO>().Add(scenarioDTO);
                await context.SaveChangesAsync();
            }
        }

        private ScenarioDTO ToScenarioDTO(BaseScenario scenario)
        {
            return new ScenarioDTO()
            {
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
