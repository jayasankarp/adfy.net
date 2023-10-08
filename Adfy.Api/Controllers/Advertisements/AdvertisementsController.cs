using System.Security.Claims;
using Adfy.Application.Advertisements.CreateAdvertisement;
using Adfy.Application.Advertisements.FindAdvertisements;
using Adfy.Application.Advertisements.GetAdvertisement;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adfy.Api.Controllers.Advertisements;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementsController(ISender sender, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> FindAdvertisements(CancellationToken cancellationToken)
    {
        var query = new FindAdvertisementsQuery();

        var result = await sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdvertisement(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAdvertisementQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAdvertisement(
        CreateAdverstisementRequest request,
        CancellationToken cancellationToken)
    {
        var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var command = new CreateAdvertisementCommand(userId!, request.Title, request.Description);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetAdvertisement), new { id = result.Value }, result.Value);
    }
}