using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Dto;
using Persistance.Repositories.Event;
using Persistance.Repositories.Speaker;

namespace Infrastructure.Servicies;

public class EventService:IEventService
{
    private readonly IEventRepository _eventRepo;
    private readonly ISpeakerRepository _speakerRepo;
    private readonly IMapper _mapper;
    private static List<Speaker> speakersList = new List<Speaker>();

    public EventService(IEventRepository eventRepo, ISpeakerRepository speakerRepo, IMapper mapper)
    {
        _eventRepo = eventRepo;
        _speakerRepo = speakerRepo;
        _mapper = mapper;
        speakersList = _speakerRepo.GetAll();
        
    }

    public async Task<List<EventDto>> GetAllEventsAsync()
    {
        return (await _eventRepo.GetAllEvents())
            .Select(ev => _mapper.Map<Event,EventDto>(ev))
            .ToList();
    }
    
    public async Task<EventDto> GetEventAsync(int eventId)
    {
        var ev = await _eventRepo.GetEvent(eventId); 
        return _mapper.Map<Event, EventDto>(ev);
    }
    
    public async Task RegisterEventAsync(RegEventDto newEvent)
    {
        var evnt = _mapper.Map<RegEventDto, Event>(newEvent);
        await _eventRepo.RegisterEvent(evnt);
    }

    public async Task UpdateEventAsync(RegEventDto newData)
    {
        var updateEvent = await _eventRepo.GetEvent(newData.Id);
        if (updateEvent != null)
        {
            updateEvent.Title = newData.Title;
            updateEvent.Description = newData.Description;
            updateEvent.Plan = newData.Plan;
            updateEvent.Date = newData.Date;
            updateEvent.Time = newData.Time;
            updateEvent.OrganizerId = newData.OrganizerId;
            updateEvent.EventSpeakers = newData.SpeakersId.Select(speakerId => new EventSpeaker
            {
                EventId = newData.Id,
                SpeakerId = speakerId
            }).ToList();
                
            await _eventRepo.SaveChangesAsync();
        }
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var deleteEvent = await _eventRepo.GetEvent(eventId);
        await _eventRepo.RemoveEvent(deleteEvent);
    }
}