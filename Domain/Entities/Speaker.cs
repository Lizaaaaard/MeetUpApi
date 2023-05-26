using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore] public ICollection<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();
    }
}
