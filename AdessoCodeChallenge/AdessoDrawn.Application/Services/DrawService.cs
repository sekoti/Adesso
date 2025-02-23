using AdessoDraw.Application.Models.RequestModels;
using AdessoDraw.Application.Models.ResponseModels;

namespace AdessoDraw.Application.Services;
public class DrawService
{
    private static List<string> GroupNames = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };

    public Task<DrawResponseModel> DrawAsync(DrawRequestModel drawRequest)
    {
        return null;
    }
}
