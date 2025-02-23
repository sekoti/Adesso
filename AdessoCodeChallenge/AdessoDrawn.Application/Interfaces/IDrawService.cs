
using AdessoDraw.Application.Models.RequestModels;
using AdessoDraw.Application.Models.ResponseModels;

namespace AdessoDraw.Application.Interfaces;

public interface IDrawService
{
    Task<DrawResponseModel> DrawAsync(DrawRequestModel drawRequest);
}