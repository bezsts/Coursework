using WPF.Common.Enums;
using WPF.Models.Requests;

namespace WPF.DTOs
{
    public class ScenarioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaxRate { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan Duration { get; set; }
        public Tests Type { get; set; }
        public int RequestParametresId { get; set; }
        public RequestParametresDTO? RequestParametres { get; set; }
    }
}
