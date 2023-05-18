using MediatR;

namespace Application.CQRS.Commands.DeleteEvent;

public class DeleteEvent:IRequest
{
    public int deleteEventId { get; set; }

    public DeleteEvent(int _delete)
    {
        deleteEventId = _delete;
    }
}