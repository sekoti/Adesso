namespace AdessoDraw.Application.Models.ResponseModels;

public class GroupResponseModel
{
    public required string GroupName { get; set; }
    public List<TeamResponseModel> Teams { get; set; } = [];
}