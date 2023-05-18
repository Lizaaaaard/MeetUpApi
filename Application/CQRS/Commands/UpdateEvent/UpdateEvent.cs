using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Commands.UpdateEvent;

public class UpdateEvent: IRequest
{
    public RegEventDto newData { get; set; } = new RegEventDto();

    public UpdateEvent(RegEventDto _newDatadata)
    {
        newData.Id = _newDatadata.Id;
        newData.Title = _newDatadata.Title;
        newData.Description = _newDatadata.Description;
        newData.Plan = _newDatadata.Plan;
        newData.Date = _newDatadata.Date;
        newData.Time = _newDatadata.Time;
        newData.OrganizerId = _newDatadata.OrganizerId;
        newData.SpeakersId = _newDatadata.SpeakersId;
    }
}