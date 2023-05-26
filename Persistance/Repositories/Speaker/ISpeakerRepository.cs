namespace Persistance.Repositories.Speaker;

public interface ISpeakerRepository
{
    List<Domain.Entities.Speaker> GetAll();
    Task AddSpeaker(Domain.Entities.Speaker speaker);
    Task<Domain.Entities.Speaker> GetSpeaker(int speakerId);
    Task RemoveSpeaker(Domain.Entities.Speaker speaker);
}