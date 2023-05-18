using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Queries.GetEvent;

public class GetEventById: IRequest<EventDto>
{
    public int Id { get; set; }

    public GetEventById(int eventId)
    {
        Id = eventId;
    }
}