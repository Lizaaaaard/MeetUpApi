using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
        [Required]
        public int OrganizerId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [Required]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):([0-5][0-9])$")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan Time { get; set; }
        public Organizer Organizer { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
