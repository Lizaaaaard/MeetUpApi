using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Event> Events { get; set; }
    }
}
