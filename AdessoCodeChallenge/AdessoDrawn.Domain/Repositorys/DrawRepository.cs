using AdessoDraw.Domain.Context;
using AdessoDraw.Domain.Entities;
using AdessoDraw.Domain.Repositorys.Interfaces;


namespace AdessoDraw.Domain.Repositorys;
public class TeamRepository : Repository<Team>, ITeamRepository
{
    public TeamRepository(DrawContext context) : base(context)
    {
    }
}
