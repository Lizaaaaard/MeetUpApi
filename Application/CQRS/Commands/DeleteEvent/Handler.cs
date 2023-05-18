using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.DeleteEvent;

public class Handler:IRequestHandler<DeleteEvent>
{
    private readonly IEventService _eventService;

    public Handler(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    public async Task Handle(DeleteEvent request, CancellationToken cancellationToken)
    {
        await _eventService.DeleteEventAsync(request.deleteEventId);
    }
}