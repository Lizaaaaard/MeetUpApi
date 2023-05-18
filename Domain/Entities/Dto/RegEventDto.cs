namespace Domain.Entities.Dto;

public class RegEventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Plan { get; set; } = string.Empty;
    public int OrganizerId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public TimeSpan Time { get; set; } = DateTime.Now.TimeOfDay;
    public List<int> SpeakersId { get; set; } = new List<int>();
}