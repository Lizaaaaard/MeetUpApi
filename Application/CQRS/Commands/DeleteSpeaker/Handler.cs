using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.DeleteSpeaker;

public class Handler:IRequestHandler<DeleteSpeaker>
{
    private readonly ISpeakerService _speakerService;
    
    public Handler(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }
    
    public async Task Handle(DeleteSpeaker request, CancellationToken cancellationToken)
    {
        await _speakerService.DeleteSpeakerAsync(request.deleteSpeakerId);
    }
}