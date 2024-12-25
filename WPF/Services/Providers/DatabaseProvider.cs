using Microsoft.EntityFrameworkCore;
using WPF.DbContexts;
using WPF.DTOs;
using WPF.Models.Requests;
using WPF.Models.Scenarious;

namespace WPF.Services.Providers
{
    public class DatabaseProvider : IScenarioProvider, IRequestProvider
    {
        private readonly DataModelContextFactory _dbContextFactory;

        public DatabaseProvider(DataModelContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<RequestParametres>> GetAllRequests()
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<RequestParametresDTO> requestParametresDTOs = await context.Set<RequestParametresDTO>().ToListAsync();

                return requestParametresDTOs.Select(x => ToRequest(x));
            }
        }

        public async Task<RequestParametres?> GetRequestParametresById(int id)
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                RequestParametresDTO? requestParametresDTO = await context.Set<RequestParametresDTO>()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (requestParametresDTO is null)
                {
                    return null;
                }
                return ToRequest(requestParametresDTO);
            }
        }

        private static RequestParametres ToRequest(RequestParametresDTO x)
        {
            RequestParametres requestParametres = new RequestParametres(x.Name, x.Url, x.Method, x.ContentType, x.Body);
            requestParametres.Id = x.Id;
            return requestParametres;
        }

        public async Task<IEnumerable<BaseScenario>> GetAllScenarious()
        {
            using (DataModelContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ScenarioDTO> scenarioDTOs = await context.Set<ScenarioDTO>()
                    .Include(s => s.RequestParametres).ToListAsync();
                return scenarioDTOs.Select(x => ScenarioFactory.CreateScenarioFromDatabase(x.Type, x));
            }
        }
    }
}
