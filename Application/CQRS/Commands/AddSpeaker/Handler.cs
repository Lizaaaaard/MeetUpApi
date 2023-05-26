using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.AddSpeaker;

public class Handler : IRequestHandler<AddSpeaker>
{
    private readonly ISpeakerService _speakerService;

    public Handler(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }
    
    public async Task Handle(AddSpeaker request, CancellationToken cancellationToken)
    {
        await _speakerService.AddSpeakerAsync(request.name);
    }
}