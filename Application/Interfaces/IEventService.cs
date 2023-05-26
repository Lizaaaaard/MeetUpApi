using Domain.Entities.Dto;

namespace Application.Interfaces;

public interface IEventService
{
    Task<List<EventDto>> GetAllEventsAsync();
    Task<EventDto> GetEventAsync(int eventId);
    Task RegisterEventAsync(RegEventDto newEvent);
    Task UpdateEventAsync(RegEventDto newData);
    Task DeleteEventAsync(int eventId);
}