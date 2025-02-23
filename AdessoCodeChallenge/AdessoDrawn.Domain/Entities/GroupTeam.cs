using AdessoDraw.Domain.Entities;
using AdessoDraw.Domain.Models;


public class GroupTeam : BaseEntity<Guid>
{
    public int TeamId { get; set; }
    public Guid GroupId { get; set; }
    public virtual Team Team { get; set; }
    public virtual Group Group { get; set; }

}