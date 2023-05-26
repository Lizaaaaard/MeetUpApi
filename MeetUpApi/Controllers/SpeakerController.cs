using Application.CQRS.Commands.AddSpeaker;
using Application.CQRS.Commands.DeleteSpeaker;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("MeetUpApi")]
[ApiController]
public class SpeakerController:ControllerBase
{
    private readonly IMediator _mediator;
    public SpeakerController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("speaker")]
    public async Task AddSpeaker(String name)
    {
        await _mediator.Send(new AddSpeaker(name));
    }
    
    [Authorize]
    [HttpDelete("speaker/{speakerId}")]
    public async Task DeleteSpeaker(int speakerId)
    {
        await _mediator.Send(new DeleteSpeaker(speakerId));
    }
}