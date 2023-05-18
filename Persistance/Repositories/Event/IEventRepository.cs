namespace Persistance.Repositories.Event;
using Domain.Entities;

public interface IEventRepository
{
    Task<List<Event>> GetAllEvents();
    Task<Event> GetEvent(int eventId);
    public Task RegisterEvent(Event newEvent);
    Task RemoveEvent(Event ev);
    Task<bool> SaveChangesAsync();
}