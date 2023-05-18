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
    private static List<Speaker> speakersList = new List<Speaker>();
    
    private static MapperConfiguration eventConfig = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDto>()
        .ForMember(e => e.Id, act => act.MapFrom(ev => ev.Id))
        .ForMember(e => e.Title, act => act.MapFrom(ev => ev.Title))
        .ForMember(e => e.Description, act => act.MapFrom(ev => ev.Description))
        .ForMember(e => e.Plan, act => act.MapFrom(ev => ev.Plan))
        .ForMember(e => e.OrganizerName, act => act.MapFrom(ev => ev.Organizer.Name))
        .ForMember(e => e.Date, act => act.MapFrom(ev => ev.Date))
        .ForMember(e => e.Time, act => act.MapFrom(ev => ev.Time))
        .ForMember(e => e.Speakers, act => act.MapFrom(ev => ev.Speakers)
        ));
    
    private static MapperConfiguration newEventConfig = new MapperConfiguration(cfg => cfg.CreateMap<RegEventDto, Event>()
        .ForMember(ev => ev.Id, act => act.MapFrom(reg => reg.Id))
        .ForMember(ev => ev.Title, act => act.MapFrom(reg => reg.Title))
        .ForMember(ev => ev.Description, act => act.MapFrom(reg => reg.Description))
        .ForMember(ev => ev.Plan, act => act.MapFrom(reg => reg.Plan))
        .ForMember(ev => ev.Date, act => act.MapFrom(reg => reg.Date))
        .ForMember(ev => ev.Time, act => act.MapFrom(reg => reg.Time))
        .ForMember(ev => ev.OrganizerId, act => act.MapFrom(reg => reg.OrganizerId))
        .ForMember(ev => ev.Speakers, act => act.MapFrom(reg => speakersList.Where(sp => reg.SpeakersId.Contains(sp.Id)))
        ));
    

    private Mapper eventMapper = new Mapper(eventConfig);
    private Mapper newEventMapper = new Mapper(newEventConfig);
    
    public EventService(IEventRepository eventRepo, ISpeakerRepository speakerRepo)
    {
        _eventRepo = eventRepo;
        _speakerRepo = speakerRepo;
        speakersList = _speakerRepo.GetAll();
    }

    public async Task<List<EventDto>> GetAllEventsAsync()
    {
        return (await _eventRepo.GetAllEvents())
            .Select(ev => eventMapper.Map<Event,EventDto>(ev))
            .ToList();
    }
    
    public async Task<EventDto> GetEventAsync(int eventId)
    {
        var ev = await _eventRepo.GetEvent(eventId); 
        return eventMapper.Map<Event, EventDto>(ev);
    }
    
    public async Task RegisterEventAsync(RegEventDto newEvent)
    {
        var evnt = newEventMapper.Map<RegEventDto, Event>(newEvent);
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
            updateEvent.Speakers = speakersList.Where(sp => newData.SpeakersId.Contains(sp.Id)).ToList();
            await _eventRepo.SaveChangesAsync();
        }
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var deleteEvent = await _eventRepo.GetEvent(eventId);
        await _eventRepo.RemoveEvent(deleteEvent);
    }
}