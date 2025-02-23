namespace AdessoDraw.Application.Models.ResponseModels;
public class DrawResponseModel
{
    public required string DrawnBy { get; set; }
    public DateTime DrawDate { get; set; }
    public List<GroupResponseModel> Groups { get; set; } = [];
}
