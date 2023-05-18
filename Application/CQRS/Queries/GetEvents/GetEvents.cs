using Domain.Entities.Dto;
using MediatR;

namespace Application.CQRS.Queries.GetEvents;

public class GetEvents: IRequest<List<EventDto>>
{
    
}