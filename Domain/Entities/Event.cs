using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
        public int OrganizerId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):([0-5][0-9])$")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan Time { get; set; }
        public Organizer Organizer { get; set; }
        public ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}
