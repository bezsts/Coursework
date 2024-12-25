using WPF.Models.Scenarious;

namespace WPF.Services.Providers
{
    public interface IScenarioProvider
    {
        Task<IEnumerable<BaseScenario>> GetAllScenarious();
    }
}
