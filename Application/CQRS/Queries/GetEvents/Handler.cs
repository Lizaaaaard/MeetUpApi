using Application.Interfaces;
using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Queries.GetEvents;

public class Handler: IRequestHandler<GetEvents, List<EventDto>>
{
    private readonly IEventService _eventService;

    public Handler(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    public async Task<List<EventDto>> Handle(GetEvents request, CancellationToken cancellationToken)
    {
        var result = await _eventService.GetAllEventsAsync();
        return result;
    }
}