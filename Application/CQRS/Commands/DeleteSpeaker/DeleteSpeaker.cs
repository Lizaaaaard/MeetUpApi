using MediatR;

namespace Application.CQRS.Commands.DeleteSpeaker;

public class DeleteSpeaker:IRequest
{
    public int deleteSpeakerId { get; set; }

    public DeleteSpeaker(int _delete)
    {
        deleteSpeakerId = _delete;
    }
}