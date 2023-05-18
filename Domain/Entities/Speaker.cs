using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Speaker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Event> Events { get; set; }
    }
}
