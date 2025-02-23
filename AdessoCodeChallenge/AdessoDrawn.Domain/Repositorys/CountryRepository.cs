using AdessoDraw.Domain.Context;
using AdessoDraw.Domain.Entities;
using AdessoDraw.Domain.Repositorys.Interfaces;

namespace AdessoDraw.Domain.Repositorys;
public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(DrawContext context) : base(context)
    {
    }
}
