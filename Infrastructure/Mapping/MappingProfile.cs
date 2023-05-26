using AutoMapper;
using Domain.Entities;
using Domain.Entities.Dto;
using Persistance.Repositories.Speaker;

namespace Infrastructure.Mapping;

public class MappingProfile: Profile
{
    private readonly ISpeakerRepository _speakerRepository;

    public MappingProfile(ISpeakerRepository speakerRepository)
    {
        _speakerRepository = speakerRepository;
        
        CreateMap<Event,EventDto>()
            .ForMember(e => e.Id, act => act.MapFrom(ev => ev.Id))
            .ForMember(e => e.Title, act => act.MapFrom(ev => ev.Title))
            .ForMember(e => e.Description, act => act.MapFrom(ev => ev.Description))
            .ForMember(e => e.Plan, act => act.MapFrom(ev => ev.Plan))
            .ForMember(e => e.OrganizerName, act => act.MapFrom(ev => ev.Organizer.Name))
            .ForMember(e => e.Date, act => act.MapFrom(ev => ev.Date))
            .ForMember(e => e.Time, act => act.MapFrom(ev => ev.Time))
            .ForMember(e => e.Speakers, act => act.MapFrom(ev => ev.EventSpeakers.Select(e=>e.Speaker))
            );

        CreateMap<RegEventDto, Event>()
            .ForMember(ev => ev.Id, act => act.MapFrom(reg => reg.Id))
            .ForMember(ev => ev.Title, act => act.MapFrom(reg => reg.Title))
            .ForMember(ev => ev.Description, act => act.MapFrom(reg => reg.Description))
            .ForMember(ev => ev.Plan, act => act.MapFrom(reg => reg.Plan))
            .ForMember(ev => ev.Date, act => act.MapFrom(reg => reg.Date))
            .ForMember(ev => ev.Time, act => act.MapFrom(reg => reg.Time))
            .ForMember(ev => ev.OrganizerId, act => act.MapFrom(reg => reg.OrganizerId))
            .ForMember(ev => ev.EventSpeakers, act => act.MapFrom(
                reg => reg.SpeakersId.Select(speakerId => new EventSpeaker
                {
                    EventId = reg.Id,
                    SpeakerId = speakerId

                }))
            );
    }
}