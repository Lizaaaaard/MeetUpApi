using MediatR;

namespace Application.CQRS.Commands.AddSpeaker;

public class AddSpeaker:IRequest
{
    public String name {get; set;} = string.Empty;
    
    public AddSpeaker (String _name)
    {
        name = _name;
    }
}