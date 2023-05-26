using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EventSpeaker
{
    public int EventId { get; set; }
    [ForeignKey("EventId")] 
    public Event Event { get; set; }
    public int SpeakerId { get; set; }
    public Speaker Speaker { get; set; }
}