using AdessoDraw.Domain.Context;
using AdessoDraw.Domain.Repositorys.Interfaces;
using AdessoDraw.Domain.Repositorys;


namespace AdessoDraw.Domain.UOW;
public class UnitOfWork : IUnitOfWork
{
    private readonly DrawContext _context;
    public ICountryRepository Countries { get; }
    public ITeamRepository Teams { get; }

    public IDrawRepository Draws { get; }

    public UnitOfWork(DrawContext context)
    {
        _context = context;
        Countries = new CountryRepository(context);
        Teams = new TeamRepository(context);
        Draws = new DrawRepository(context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

