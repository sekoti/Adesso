using AdessoDraw.Domain.Repositorys.Interfaces;


namespace AdessoDraw.Domain.UOW;
public interface IUnitOfWork : IDisposable
{
    ICountryRepository Countries { get; }
    ITeamRepository Teams { get; }

    IDrawRepository Draws { get; }
    Task<int> SaveAsync();
}
