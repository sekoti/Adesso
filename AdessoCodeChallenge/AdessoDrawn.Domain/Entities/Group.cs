using AdessoDraw.Domain.Models;

namespace AdessoDraw.Domain.Entities;
public class Group:BaseEntity<Guid>
{
    public string GroupName { get; set; }
    public int GroupCount { get; set; }
    public Guid DrawId { get; set; }
    public virtual Draw Draw { get; set; }

    public virtual List<GroupTeam> GroupTeams { get; set; } = [];
}