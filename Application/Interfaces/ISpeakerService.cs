namespace Application.Interfaces;

public interface ISpeakerService
{
    Task AddSpeakerAsync(String speakerName);
    Task DeleteSpeakerAsync(int speakerId);
}