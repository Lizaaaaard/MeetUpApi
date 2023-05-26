using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Speaker;

public class SpeakerRepository:ISpeakerRepository
{
    private readonly AppDbContext _ctx;

    public SpeakerRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public List<Domain.Entities.Speaker> GetAll()
    {
       return _ctx.Speakers.AsNoTracking().ToList();
    }
    
    public async Task AddSpeaker(Domain.Entities.Speaker speaker)
    {
       await _ctx.Speakers.AddAsync(speaker);
       await _ctx.SaveChangesAsync();
    }
    
    public async Task<Domain.Entities.Speaker> GetSpeaker(int speakerId)
    {
        return await _ctx.Speakers.Where(sp => sp.Id == speakerId).FirstOrDefaultAsync();
    }
    
    public async Task RemoveSpeaker(Domain.Entities.Speaker speaker)
    {
        _ctx.Speakers.Remove(speaker);
        await _ctx.SaveChangesAsync();
    }
}