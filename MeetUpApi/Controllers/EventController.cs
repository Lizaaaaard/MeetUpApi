using Application.CQRS.Commands.DeleteEvent;
using Application.CQRS.Commands.RegisterEvent;
using Application.CQRS.Commands.UpdateEvent;
using Application.CQRS.Queries.GetEvent;
using Application.CQRS.Queries.GetEvents;
using Domain.Entities.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetUpApi.Controllers
{
    [Route("MeetUpApi")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet("events")]
        public async Task<ActionResult> GetAllEvents()
        {
            var events = await _mediator.Send(new GetEvents());
            return Ok(events);
        }
        
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult> GetEvent(int eventId)
        {
            var ev = await _mediator.Send(new GetEventById(eventId));
            return Ok(ev);
        }
        
        [HttpPost("event")]
        public async Task RegisterEvent([FromBody] RegEventDto newEvent)
        {
            await _mediator.Send(new RegisterEvent(newEvent));
        }
        
        [HttpPut("event/{newData.Id}")]
        public async Task UpdateEvent([FromBody] RegEventDto newData)
        {
            await _mediator.Send(new UpdateEvent(newData));
        }
        
        [Authorize]
        [HttpDelete("event/{eventId}")]
        public async Task DeleteEvent(int eventId)
        {
            await _mediator.Send(new DeleteEvent(eventId));
        }
    }
}