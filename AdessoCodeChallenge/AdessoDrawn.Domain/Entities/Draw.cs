using AdessoDraw.Domain.Models;

namespace AdessoDraw.Domain.Entities;

public class Draw :BaseEntity<Guid>
{
    public string DrawnBy { get; set; }
    public DateTime DrawDate { get; set; }
    public virtual List<Group> Groups { get; set; } = [];
}
