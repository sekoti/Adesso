using AdessoDraw.Domain.Models;

namespace AdessoDraw.Domain.Entities;

public class Team : BaseEntity<int>
{
    public required string Name { get; set; }
    public int CountryId { get; set; }

    public virtual Country Country { get; set; }
}