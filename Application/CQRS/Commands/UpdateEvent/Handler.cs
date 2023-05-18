using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.UpdateEvent;

public class Handler: IRequestHandler<UpdateEvent>
{
    private readonly IEventService _eventService;

    public Handler(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    public async Task Handle(UpdateEvent request, CancellationToken cancellationToken)
    {
        await _eventService.UpdateEventAsync(request.newData);
    }
}