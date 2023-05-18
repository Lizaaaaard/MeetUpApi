using Domain.Entities;
using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Commands.RegisterEvent;

public class RegisterEvent:IRequest
{
    public RegEventDto newEvent {get; set;} = new RegEventDto();
    
    public  RegisterEvent (RegEventDto _new)
    {
        newEvent.Id = _new.Id;
        newEvent.Title = _new.Title;
        newEvent.Description = _new.Description;
        newEvent.Plan = _new.Plan;
        newEvent.Date = _new.Date;
        newEvent.Time = _new.Time;
        newEvent.OrganizerId = _new.OrganizerId;
        newEvent.SpeakersId = _new.SpeakersId;
    }
}