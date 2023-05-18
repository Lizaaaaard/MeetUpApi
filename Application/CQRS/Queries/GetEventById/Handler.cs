using Application.Interfaces;
using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Queries.GetEvent;

public class Handler: IRequestHandler<GetEventById, EventDto>
{
    private readonly IEventService _eventService;

    public Handler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<EventDto> Handle(GetEventById request, CancellationToken cancellationToken)
    {
        var result = await _eventService.GetEventAsync(request.Id);
        return result;
    }
}