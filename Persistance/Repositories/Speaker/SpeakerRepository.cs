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
       return _ctx.Speakers.ToList();
    }
}