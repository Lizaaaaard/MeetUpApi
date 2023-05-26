namespace Domain.Entities.Dto;

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Plan { get; set; } = string.Empty;
    public string OrganizerName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public List<Speaker> Speakers { get; set; } = new List<Speaker>();
}