using WPF.Models.Scenarious;

namespace WPF.Services.Creators
{
    public interface IScenarioCreator
    {
        Task CreateScenario(BaseScenario scenario);
    }
}
