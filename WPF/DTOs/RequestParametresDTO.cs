namespace WPF.DTOs
{
    public class RequestParametresDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Method { get; set; } = "GET";
        public string Url { get; set; } = null!;

        public string ContentType { get; set; } = "application/json";
        public string Body { get; set; } = string.Empty;

        public List<ScenarioDTO>? Scenarios { get; set; }
    }
}
