namespace Persistance.Repositories.Speaker;

public interface ISpeakerRepository
{
    List<Domain.Entities.Speaker> GetAll();
}