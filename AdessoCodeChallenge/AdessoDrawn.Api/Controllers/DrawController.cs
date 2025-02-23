using AdessoDraw.Application.Interfaces;
using AdessoDraw.Application.Models.RequestModels;
using AdessoDraw.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdessoDraw.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrawController(IDrawService drawService) : ControllerBase
{
    private readonly IDrawService _drawService = drawService;

    [HttpPost("draw")]
    public async Task<IActionResult> DrawAsync([FromBody] DrawRequestModel drawRequest)
    {
        try
        {
            var result = await _drawService.DrawGroupsAsync(drawRequest);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
