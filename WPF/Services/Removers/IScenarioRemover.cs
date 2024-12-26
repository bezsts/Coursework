using WPF.Models.Scenarious;

namespace WPF.Services.Removers
{
    public interface IScenarioRemover
    {
        Task DeleteScenario(BaseScenario scenario);
    }
}
