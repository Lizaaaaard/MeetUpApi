using Application.Interfaces;
using Domain.Entities;
using Persistance.Repositories.Speaker;

namespace Infrastructure.Servicies;

public class SpeakerService:ISpeakerService
{
    private readonly ISpeakerRepository _speakerRepo;
    
    public SpeakerService(ISpeakerRepository speakerRepo)
    {
        _speakerRepo = speakerRepo;
    }

    public async Task AddSpeakerAsync(String speakerName)
    {
        _speakerRepo.AddSpeaker(new Speaker { Name = speakerName });
    }
    
    public async Task DeleteSpeakerAsync(int speakerId)
    {
        var deleteSpeaker = await _speakerRepo.GetSpeaker(speakerId);
        await _speakerRepo.RemoveSpeaker(deleteSpeaker);
    }
}