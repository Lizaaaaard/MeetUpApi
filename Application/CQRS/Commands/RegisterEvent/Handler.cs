using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.RegisterEvent;

public class Handler: IRequestHandler<RegisterEvent>
{
    private readonly IEventService _eventService;

    public Handler(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    public async Task Handle(RegisterEvent request, CancellationToken cancellationToken)
    {
        await _eventService.RegisterEventAsync(request.newEvent);
    }
}