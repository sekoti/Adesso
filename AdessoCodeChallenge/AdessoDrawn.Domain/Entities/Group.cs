namespace AdessoDraw.Domain.Entities;
public class Group
{
    public string GroupName { get; set; }
    public virtual List<Team> Teams { get; set; } = [];
}