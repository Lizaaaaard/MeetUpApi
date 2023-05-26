using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Event;

public class EventRepository: IEventRepository
{
    private readonly AppDbContext _ctx;

    public EventRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<List<Domain.Entities.Event>> GetAllEvents()
    {
        return _ctx.Events
            .Include(e => e.EventSpeakers)
            .ThenInclude(e => e.Speaker)
            .Include(e => e.Organizer)
            .ToList();
    }
    
    public async Task<Domain.Entities.Event> GetEvent(int? eventId)
    {
        return _ctx.Events
            .Include(e => e.EventSpeakers)
            .ThenInclude(e => e.Speaker)
            .Include(e => e.Organizer)
            .Where(ev => ev.Id == eventId).FirstOrDefault();
    }
    
    public async Task RegisterEvent(Domain.Entities.Event newEvent)
    {
        await _ctx.Events.AddAsync(newEvent);
        await _ctx.SaveChangesAsync();
    }

    public async Task RemoveEvent(Domain.Entities.Event ev)
    {
        _ctx.Events.Remove(ev);
        await _ctx.SaveChangesAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        if (await _ctx.SaveChangesAsync() > 0)
            return true;
        else
            return false;
    }
}